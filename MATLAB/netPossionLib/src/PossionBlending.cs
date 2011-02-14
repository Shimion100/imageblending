/*
* MATLAB Compiler: 4.14 (R2010b)
* Date: Sat Jan 29 20:57:57 2011
* Arguments: "-B" "macro_default" "-W" "dotnet:netPossionLib,PossionBlending,0.0,private"
* "-T" "link:lib" "-d" "D:\code\vision\ImageBlending\MATLAB\netPossionLib\src" "-w"
* "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v" "class{PossionBlending:D:\code\vision\ImageBlending\MATLAB\BlendImage.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace netPossionLib
{
  /// <summary>
  /// The PossionBlending class provides a CLS compliant, MWArray interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// D:\code\vision\ImageBlending\MATLAB\BlendImage.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class PossionBlending : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static PossionBlending()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = "netPossionLib.ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR("",
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the PossionBlending class.
    /// </summary>
    public PossionBlending()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~PossionBlending()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    ///
    public void BlendImage()
    {
      mcr.EvaluateFunction(0, "BlendImage", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="imageSrc">Input argument #1</param>
    ///
    public void BlendImage(MWArray imageSrc)
    {
      mcr.EvaluateFunction(0, "BlendImage", imageSrc);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    ///
    public void BlendImage(MWArray imageSrc, MWArray imageDst)
    {
      mcr.EvaluateFunction(0, "BlendImage", imageSrc, imageDst);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    ///
    public void BlendImage(MWArray imageSrc, MWArray imageDst, MWArray imageMask)
    {
      mcr.EvaluateFunction(0, "BlendImage", imageSrc, imageDst, imageMask);
    }


    /// <summary>
    /// Provides a void output, 4-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <param name="imageSave">Input argument #4</param>
    ///
    public void BlendImage(MWArray imageSrc, MWArray imageDst, MWArray imageMask, MWArray 
                     imageSave)
    {
      mcr.EvaluateFunction(0, "BlendImage", imageSrc, imageDst, imageMask, imageSave);
    }


    /// <summary>
    /// Provides a void output, 5-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <param name="imageSave">Input argument #4</param>
    /// <param name="boxSrc">Input argument #5</param>
    ///
    public void BlendImage(MWArray imageSrc, MWArray imageDst, MWArray imageMask, MWArray 
                     imageSave, MWArray boxSrc)
    {
      mcr.EvaluateFunction(0, "BlendImage", imageSrc, imageDst, imageMask, imageSave, boxSrc);
    }


    /// <summary>
    /// Provides a void output, 6-input MWArrayinterface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <param name="imageSave">Input argument #4</param>
    /// <param name="boxSrc">Input argument #5</param>
    /// <param name="posDest">Input argument #6</param>
    ///
    public void BlendImage(MWArray imageSrc, MWArray imageDst, MWArray imageMask, MWArray 
                     imageSave, MWArray boxSrc, MWArray posDest)
    {
      mcr.EvaluateFunction(0, "BlendImage", imageSrc, imageDst, imageMask, imageSave, boxSrc, posDest);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageSrc">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut, MWArray imageSrc)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", imageSrc);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut, MWArray imageSrc, MWArray imageDst)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", imageSrc, imageDst);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut, MWArray imageSrc, MWArray imageDst, 
                          MWArray imageMask)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", imageSrc, imageDst, imageMask);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <param name="imageSave">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut, MWArray imageSrc, MWArray imageDst, 
                          MWArray imageMask, MWArray imageSave)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", imageSrc, imageDst, imageMask, imageSave);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <param name="imageSave">Input argument #4</param>
    /// <param name="boxSrc">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut, MWArray imageSrc, MWArray imageDst, 
                          MWArray imageMask, MWArray imageSave, MWArray boxSrc)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", imageSrc, imageDst, imageMask, imageSave, boxSrc);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the BlendImage M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// boxSrc=zeros(4);
    /// posDest=zeros(2);
    /// Load parameters
    /// {
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageSrc">Input argument #1</param>
    /// <param name="imageDst">Input argument #2</param>
    /// <param name="imageMask">Input argument #3</param>
    /// <param name="imageSave">Input argument #4</param>
    /// <param name="boxSrc">Input argument #5</param>
    /// <param name="posDest">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] BlendImage(int numArgsOut, MWArray imageSrc, MWArray imageDst, 
                          MWArray imageMask, MWArray imageSave, MWArray boxSrc, MWArray 
                          posDest)
    {
      return mcr.EvaluateFunction(numArgsOut, "BlendImage", imageSrc, imageDst, imageMask, imageSave, boxSrc, posDest);
    }


    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
