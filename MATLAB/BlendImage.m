%
% Blend the image
% 
% parameters
% imageSrc - source image
% imageDst - destination image
% imageMask - Mask image
% imageSave - Save result path
% boxSrc - the rectangular box for the selection in source, [x0 x1 y0 y1]
% posDest - the upper left corner of the source should go to this position
% in the destination image [x0 y0]
function BlendImage(imageSrc,imageDst,imageMask,imageSave,boxSrc,posDest)

    %boxSrc=zeros(4);
    %posDest=zeros(2);
    %Load parameters
    %{
    file=fopen(argsPath,'r');
    imageSrc=fscanf(file,'%s\r\n');
    imageDst=fscanf(file,'imgDst=%s\r\n');
    imageMask=fscanf(file,'imgMask=%s\r\n');
    imageSave=fscanf(file,'imgSave=%s\r\n');
    %[boxSrc(1),boxSrc(2),boxSrc(3),boxSrc(4)]
    boxSrc=fscanf(file,'boxSrc= %d, %d, %d, %d\n');
    %[posDest(1),posDest(2)]
    posDest=fscanf(file,'posDest= %d, %d\n');    
    %}

    im = double(imread(imageDst));

    iminsert = double(imread(imageSrc));
    imMask=uint8(imread(imageMask));

    t=tic;
    [imr img imb] = decomposeRGB(im);
    [imir imig imib] = decomposeRGB(iminsert);

    imr = poissonSolverMask(imir, imr, boxSrc, posDest, imMask);
    img = poissonSolverMask(imig, img, boxSrc, posDest, imMask);
    imb = poissonSolverMask(imib, imb, boxSrc, posDest, imMask);

    imnew = composeRGB(imr, img, imb);
    toc(t);
    imnew = uint8(imnew);
    figure(100);
    imshow(imnew);
    imwrite(imnew, imageSave, 'JPG');
end