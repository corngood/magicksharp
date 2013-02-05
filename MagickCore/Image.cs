using System;
using System.Runtime.InteropServices;

namespace MagickCore
{
	public unsafe struct ImageInfo
	{
		public CompressionType compression;
		public OrientationType orientation;
		public MagickBooleanType temporary, adjoin, affirm, antialias;
		public byte* size, extract, page, scenes;
		public UIntPtr scene, number_scenes, depth;
		public InterlaceType interlace;
		public EndianType endian;
		public ResolutionType units;
		public UIntPtr quality;
		public byte* sampling_factor, server_name, font, texture, density;
		public double pointsize, fuzz;
		public PixelPacket background_color, border_color, matte_color;
		public MagickBooleanType dither, monochrome;
		public UIntPtr colors;
		public ColorspaceType colorspace;
		public ImageType type;
		public PreviewType preview_type;
		public IntPtr group;
		public MagickBooleanType ping, verbose;
		public byte* view, authenticate;
		public ChannelType channel;
		public void* attributes;  /* deprecated */
		public void* options;
		public void* progress_monitor; // MagickBooleanType (*)(const char *, MagickOffsetType, MagickSizeType, void *)
		public void* client_data, cache;
		public void* stream; //size_t (*)(const Image *, const void *, size_t)
		public void* file;
		public void* blob;
		public UIntPtr length;
		public fixed byte magick[Constants.MaxTextExtent];
		public fixed byte unique[Constants.MaxTextExtent];
		public fixed byte zero[Constants.MaxTextExtent];
		public fixed byte filename[Constants.MaxTextExtent];
		public MagickBooleanType debug;
		public byte* tile;  /* deprecated */
		public UIntPtr subimage, subrange;  /* deprecated */
		public PixelPacket pen;  /* deprecated */
		public UIntPtr signature;
		public VirtualPixelMethod virtual_pixel_method;
		public PixelPacket transparent_color;
		public void* profile;
		public MagickBooleanType synchronize;
	}

	public static partial class NativeMethods
	{
		[DllImport(Library)]
		public static extern unsafe ImageInfo *AcquireImageInfo();
		
		[DllImport(Library)]
		public static extern unsafe ImageInfo *DestroyImageInfo(ImageInfo *info);
		
		[DllImport(Library)]
		public static extern unsafe Image *PingImage(ImageInfo *image_info, ExceptionInfo *exception);
		
		[DllImport(Library)]
		public static extern unsafe Image *ReadImage(ImageInfo *image_info, ExceptionInfo *exception);

		[DllImport(Library)]
		public static extern unsafe Image *DestroyImage(Image *image);
	}
}

