function [imNew] = poissonSolverMask(imSrc, imDest, boxSrc, posDest,Mask)
%
% rectangular solver
% 
% parameters
% imSrc - source image
% imDest - destination image
% boxSrc - the rectangular box for the selection in source, [x0 x1 y0 y1]
% posDest - the upper left corner of the source should go to this position
% in the destination image [x0 y0]

% --------------------------------------------
% global variables
% --------------------------------------------
laplacian = [0 1 0; 1 -4 1; 0 1 0];

MASK_HANDLE_REGION = 128;
% height and width of both the source image and the destination image
[heightSrc widthSrc] = size(imSrc);
[heightDest widthDest] = size(imDest);

% the four corners of the selected region in the source image
x0s = 1;
x1s = boxSrc(2);
y0s = 1;
y1s = boxSrc(4);

xOffset=boxSrc(1);
yOffset=boxSrc(3);

% the starting pixel of the region in the destination image
x0d = posDest(1)-1;
y0d = posDest(2)-1;

% the height and width of the region
heightRegion = y1s - y0s + 1;
widthRegion = x1s - x0s + 1;

% --------------------------------------------

%---------------------------------------------
% check for boundary conditions
%---------------------------------------------
% here, we make sure that the boundary of the region
% does not coinside with the boundary of either the source
% image or the destination image
if x0s <= 1 | x1s >= widthSrc | y0s <= 1 | y1s >= heightSrc | x0d < 1 | y0d < 1
    fprintf('Error - cannot handle such boundary condition\n');
end

fprintf('Computing mask map\n');
tic;
n=1;id=0;x=0;y=0;
Mp = containers.Map(0,0);
for y = yOffset:heightRegion
    for x = xOffset:widthRegion
        if Mask(y,x) > MASK_HANDLE_REGION
            id = (y-1) * widthRegion + x;
            Mp(id)=n;
            n=n+1;
        end
    end
end
toc;

n=n-1;
%---------------------------------------------
% sparse matrix allocation
%---------------------------------------------
fprintf('Matrix dimension = %d x %d\n', n, n);
M = spalloc(n, n, 5*n);

% also the boundary condition
b = zeros(1, n);

%---------------------------------------------
% construct the matrix here
%---------------------------------------------

tic
imLaplacian = conv2(imSrc, -laplacian, 'same');

% matrix row count
count = 1;
index=0;
try
    for y = yOffset:heightRegion
        for x = xOffset:widthRegion

            if Mask(y,x) <= MASK_HANDLE_REGION
                continue;
            end
            % index of the vector
            id = (y-1) * widthRegion + x;      

            %------------------------------------------------------
            % if Neighbourhood(p) is in the interia of the region
            %------------------------------------------------------
            offsetY=y-yOffset;
            offsetX=x-xOffset;

            % gathering the coefficient for the matrix
            %------------------------------------------------------
            % if on the top
            if y == 1 || Mask(y-1,x) <= MASK_HANDLE_REGION
                b(count) = b(count) + imDest(offsetY+y0d-1, offsetX+x0d);
            else
                index = Mp(id-widthRegion);
                M(count, index) = -1;
            end

            if y == heightRegion || Mask(y+1,x) <= MASK_HANDLE_REGION
                b(count) = b(count) + imDest(offsetY+y0d+1, offsetX+x0d);
            else
                index = Mp(id+widthRegion);
                M(count, index) = -1;
            end

            if x==1 || Mask(y,x-1) <= MASK_HANDLE_REGION
                b(count) = b(count) + imDest(offsetY+y0d, offsetX+x0d-1);
            else
                index = Mp(id-1);
                M(count, index) = -1;
            end

            if x== widthRegion || Mask(y,x+1) <= MASK_HANDLE_REGION
                 b(count) = b(count) + imDest(offsetY+y0d, offsetX+x0d+1);
            else
                index = Mp(id+1);
                M(count, index) = -1;
            end

            index = Mp(id);
            M(count, index) = 4;

            %v = imLaplacian(yv, xv);
            v = imLaplacian(y, x);
            b(count) = b(count)+v;

            count = count + 1; 
        end
    end
catch exception
    str=sprintf('At (%d,%d) id=%d',x,y,id);
    fprintf(str);
end
toc

%---------------------------------------------
% solve for the sparse matrix
%---------------------------------------------
tic
% use bi-conjugate gradient method to solve the matrix
X = bicg(M, b', [], 400);
toc

% reshape x to become the pixel intensity of the region
%imRegion = reshape(X, widthRegion, heightRegion);


%---------------------------------------------
% show the region using in 3D
%---------------------------------------------


% x = x0:h1:x1;  y = y0:h2:y1;
% [xnew,ynew] = meshgrid(x,y);
% figure(50)
% mesh(xnew,ynew,unew,'EdgeColor','black');
% xlabel('x'); ylabel('y'); zlabel('Solution, u')
% 
% filename = '../images/poissonSolverResult.jpg';
% print( gcf, '-djpeg100', filename); 

%----------------------------------------------
% compose the image
%----------------------------------------------
imNew = imDest;
n=1;

for y = yOffset:heightRegion
    for x = xOffset:widthRegion
        try
            if(Mask(y,x) > MASK_HANDLE_REGION)
                imNew(y+y0d-yOffset,x+x0d-xOffset)=X(n);
                n=n+1;
            end
        catch
            str=sprintf('Error At (%d,%d) n=%d\n',x,y,n);
            fprintf(str);
        end
    end
end
