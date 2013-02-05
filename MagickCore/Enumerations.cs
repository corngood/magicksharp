using System;

namespace MagickCore
{
	public enum ColorspaceType
	{
		Undefined,
		RGB,
		GRAY,
		Transparent,
		OHTA,
		Lab,
		XYZ,
		YCbCr,
		YCC,
		YIQ,
		YPbPr,
		YUV,
		CMYK,
		sRGB,
		HSB,
		HSL,
		HWB,
		Rec601Luma,
		Rec601YCbCr,
		Rec709Luma,
		Rec709YCbCr,
		Log,
		CMY
	}

	public enum StorageType
	{
		Undefined,
		Char,
		Double,
		Float,
		Integer,
		Long,
		Quantum,
		Short
	};

	public enum AlphaChannelType
	{
		Undefined,
		Activate,
		Background,
		Copy,
		Deactivate,
		Extract,
		Opaque,
		Reset,  /* deprecated */
		Set,
		Shape,
		Transparent,
		Flatten,
		Remove
	}
	
	public enum ImageType
	{
		Undefined,
		Bilevel,
		Grayscale,
		GrayscaleMatte,
		Palette,
		PaletteMatte,
		TrueColor,
		TrueColorMatte,
		ColorSeparation,
		ColorSeparationMatte,
		Optimize,
		PaletteBilevelMatte
	}
	
	public enum InterlaceType
	{
		Undefined,
		No,
		Line,
		Plane,
		Partition,
		GIF,
		JPEG,
		PNG
	}
	
	public enum OrientationType
	{
		Undefined,
		TopLeft,
		TopRight,
		BottomRight,
		BottomLeft,
		LeftTop,
		RightTop,
		RightBottom,
		LeftBottom
	}
	
	public enum ResolutionType
	{
		Undefined,
		PixelsPerInch,
		PixelsPerCentimeter
	}

	public enum FilterType
	{
		Undefined,
		Point,
		Box,
		Triangle,
		Hermite,
		Hanning,
		Hamming,
		Blackman,
		Gaussian,
		Quadratic,
		Cubic,
		Catrom,
		Mitchell,
		Jinc,
		Sinc,
		SincFast,
		Kaiser,
		Welsh,
		Parzen,
		Bohman,
		Bartlett,
		Lagrange,
		Lanczos,
		LanczosSharp,
		Lanczos2,
		Lanczos2Sharp,
		Robidoux,
		RobidouxSharp,
		Cosine,
		Spline,
		LanczosRadius,
		Sentinel  /* a count of all the filters, not a real filter */
	}
}
