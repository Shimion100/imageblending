% im = double(imread('../images/orange.tif', 'TIF'));
% figure;
% imshow(mat2gray(im));
% 
% iminsert = double(imread('../images/orange.tif', 'TIF'));
% figure;
% imshow(mat2gray(iminsert));

im = double(imread('E:/ͼƬ/blending/b.jpg', 'jpg'));
figure;
imshow(mat2gray(im));

iminsert = double(imread('E:/ͼƬ/blending/a.jpg', 'jpg'));
imMask=uint8(imread('E:/ͼƬ/blending/tmpMask.jpg'));
figure;
imshow(mat2gray(iminsert));


[imr img imb] = decomposeRGB(im);
[imir imig imib] = decomposeRGB(iminsert);

boxSrc = [58 136 73 146 ];
posDest = [201 277];

imr = poissonSolverMask(imir, imr, boxSrc, posDest,imMask);
img = poissonSolverMask(imig, img, boxSrc, posDest,imMask);
imb = poissonSolverMask(imib, imb, boxSrc, posDest,imMask);

imnew = composeRGB(imr, img, imb);
imnew = uint8(imnew);
figure(100);
imshow(imnew);
imwrite(imnew, 'test001Result.jpg', 'JPG');
% poisson1(50, 51, 5);


% im = double(imread('../images/test001BW.tif', 'TIFF'));
% figure;
% imshow(mat2gray(im));