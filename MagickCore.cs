using System;
using System.Runtime.InteropServices;

namespace MagickCore
{
	public static class Constants
	{
		public const int MaxTextExtent = 4096;
	}

	public enum ClassType {}
	public enum RenderingIntent {}
	public enum FilterTypes {}
	public enum GravityType {}
	public enum DisposeType {}
	public enum CompositeOperator {}

	public struct PrimaryInfo
	{
		public double x, y, z;
	}

	public struct ChromaticityInfo
	{
		public PrimaryInfo red_primary, green_primary, blue_primary, white_point;
	}

	public struct RectangleInfo
	{
		public UIntPtr width, height;
		public IntPtr x, y;
	}

	public struct ErrorInfo
	{
		public double mean_error_per_pixel, normalized_mean_error, normalized_maximum_error;
	}

	public enum TimerState {}

	public struct Timer
	{
		public double start, stop, total;
	}

	public struct TimerInfo
	{ 
		public Timer user, elapsed;
		public TimerState state;
		public UIntPtr signature;
	}

	public struct Ascii85Info {}

	public struct BlobInfo {}

	public unsafe struct ProfileInfo
	{
		public byte* name;
		public UIntPtr length;
		public byte* info;
		public UIntPtr signature;
	}

	public enum InterpolatePixelMethod {}

	public struct MagickSizeType { public ulong Value; }

	public unsafe struct Image
	{
		public ClassType storage_class;
		public ColorspaceType colorspace;
		public CompressionType compression;
		public UIntPtr quality;
		public OrientationType orientation;
		public MagickBooleanType taint, matte;
		public UIntPtr columns, rows, depth, colors;
		public PixelPacket* colormap;
		public PixelPacket background_color, border_color, matte_color;
		public double gamma;
		public ChromaticityInfo chromaticity;
		public RenderingIntent rendering_intent;
		public void *profiles;		
		public ResolutionType units;
		public byte* montage, directory, geometry;
		public IntPtr offset;
		public double x_resolution, y_resolution;
		public RectangleInfo page, extract_info, tile_info;
		public double bias, blur, fuzz;
		public FilterTypes filter;
		public InterlaceType interlace;
		public EndianType endian;
		public GravityType gravity;
		public CompositeOperator compose;
		public DisposeType dispose;
		public Image* clip_mask;
		public UIntPtr scene, delay;
		public IntPtr ticks_per_second;
		public UIntPtr iterations, total_colors;
		public IntPtr start_loop;
		public ErrorInfo error;
		public TimerInfo timer;
		public void* progress_monitor; //MagickBooleanType (*)(const char *, MagickOffsetType, MagickSizeType, void *)
		public void* client_data, cache, attributes;
		public Ascii85Info* ascii85;
		public BlobInfo* blob;
		public fixed byte filename[Constants.MaxTextExtent];
		public fixed byte magick_filename[Constants.MaxTextExtent];
		public fixed byte magick[Constants.MaxTextExtent];
		public UIntPtr magick_columns, magick_rows;
		public ExceptionInfo exception;
		public MagickBooleanType debug;
		public volatile IntPtr reference_count;
		public SemaphoreInfo* semaphore;
		public ProfileInfo color_profile, iptc_profile;
		public ProfileInfo* generic_profile;
		public UIntPtr generic_profiles;
		public UIntPtr signature;
		public Image* previous, list, next;
		public InterpolatePixelMethod interpolate;
		public MagickBooleanType black_point_compensation;
		public PixelPacket transparent_color;
		public Image* mask;
		public RectangleInfo tile_offset;
		public void* properties, artifacts;
		public ImageType type;
		public MagickBooleanType dither;
		public MagickSizeType extent;
		public MagickBooleanType ping;
		public UIntPtr channels;
	}

	public enum ExceptionType {}
	public enum CompressionType {}
	public enum EndianType {}
	public enum PreviewType {}
	public enum ChannelType {}
	public enum VirtualPixelMethod {}

	public struct Quantum { public ushort Value; }

	public struct PixelPacket { public Quantum blue, green, red, opacity; }

	public struct MagickBooleanType { public uint Value; }

	public struct SemaphoreInfo {}
	
	public unsafe struct ExceptionInfo
	{
		public ExceptionType severity;
		public int error_number;
		public byte* reason, description;
		public void* exceptions;
		public MagickBooleanType relinquish;
		public SemaphoreInfo* semaphore;
		public UIntPtr signature;
	}

	public static partial class NativeMethods
	{
		public const string Library = "MagickCore.dll";

		[DllImport(Library)]
		public static extern unsafe ExceptionInfo *AcquireExceptionInfo();
		
		[DllImport(Library)]
		public static extern unsafe ExceptionInfo *DestroyExceptionInfo(ExceptionInfo *info);

		[DllImport(Library)]
		public static extern unsafe UIntPtr CopyMagickString(byte *destination, string source, UIntPtr length);
	}
}

