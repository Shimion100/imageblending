**_How to use the kernel of the Poisson blending_**

# Introduction #
There are multi files in the zip file. You can decompress that file and run the kernel individually. The kernel is tested on MATLAB r2010b.

# Details #
  * Entry function
> > You should call BlendImage function, implemented in BlendImage.m to blend an image. The function is called like:
```
function BlendImage(imageSrc,imageDst,imageMask,imageSave,boxSrc,posDest)
```
## parameters ##
  1. imageSrc - source image path.
  1. imageDst - destination image path.
  1. imageMask - Mask image path.
  1. imageSave - Save result path.
  1. boxSrc - the rectangular box for the selection in source.
#  posDest - the upper left corner of the source should go to this position in the destination image.

## The algorithm ##
The Poisson image editing algorithm is implemented in poissonSolverMask.m, you can read the code if you are interested.

**I don't guarantee there is no bug in these files.**

If you find any bug, please add an issue on the Issues page.
Thank you.