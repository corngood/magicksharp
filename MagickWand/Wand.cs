using System;
using System.Runtime.InteropServices;

using MagickCore;

namespace MagickWand
{
	public class Wand : NativeObject
	{
		static class Native
		{
			[DllImport(Library)] public static extern IntPtr NewMagickWand();
			[DllImport(Library)] public static extern IntPtr DestroyMagickWand(IntPtr wand);
			[DllImport(Library)] public static extern void ClearMagickWand(IntPtr wand);
			[DllImport(Library)] public static extern bool MagickNewImage(IntPtr wand, UIntPtr columns, UIntPtr rows, IntPtr background);
			[DllImport(Library)] public static extern bool MagickReadImage(IntPtr wand, string filename);
			[DllImport(Library)] public static extern bool MagickReadImageBlob<T>(IntPtr wand, T[] filename) where T : struct;
			[DllImport(Library)] public static extern bool MagickPingImage(IntPtr wand, string filename);
			[DllImport(Library)] public static extern bool MagickWriteImage(IntPtr wand, string filename);
			[DllImport(Library)] public static extern IntPtr MagickGetImageBlob(IntPtr wand, out UIntPtr size);
			[DllImport(Library)] public static extern bool MagickExportImagePixels<T>(IntPtr wand, IntPtr x, IntPtr y, UIntPtr columns, UIntPtr rows, string map, StorageType storage, T[] pixels) where T : struct;
			[DllImport(Library)] public static extern UIntPtr MagickGetImageWidth(IntPtr wand);
			[DllImport(Library)] public static extern UIntPtr MagickGetImageHeight(IntPtr wand);
			[DllImport(Library)] public static extern bool MagickResizeImage(IntPtr wand, UIntPtr columns, UIntPtr rows, FilterType filter, double blur);
			[DllImport(Library)] public static extern string MagickGetImageFormat(IntPtr wand);
			[DllImport(Library)] public static extern void MagickSetImageFormat(IntPtr wand, string format);
			[DllImport(Library)] public static extern ColorspaceType MagickGetImageColorspace(IntPtr wand);
			[DllImport(Library)] public static extern void MagickSetImageColorspace(IntPtr wand, ColorspaceType colorspace);
			[DllImport(Library)] public static extern ImageType MagickGetImageType(IntPtr wand);
			[DllImport(Library)] public static extern void MagickSetImageType(IntPtr wand, ImageType type);
		}

		public Wand() : base(Native.NewMagickWand())
		{
		}

		protected override void Dispose(bool disposing)
		{
			Native.DestroyMagickWand(Handle);
		}

		public void Clear()
		{
			Native.ClearMagickWand(Handle);
		}

		public void NewImage(ulong columns, ulong rows, PixelWand background)
		{
			Test(Native.MagickNewImage(Handle, (UIntPtr)columns, (UIntPtr)rows, background.Handle));
		}

		public void ReadImage(string filename)
		{
			Test(Native.MagickReadImage(Handle, filename));
		}

		public void ReadImage<T>(T[] blob) where T : struct
		{
			Test(Native.MagickReadImageBlob(Handle, blob));
		}

		public void PingImage(string filename)
		{
			Test(Native.MagickPingImage(Handle, filename));
		}

		public void WriteImage(string filename)
		{
			Test(Native.MagickWriteImage(Handle, filename));
		}

		public byte[] GetImageBlob()
		{
			UIntPtr size;
			var blob = Native.MagickGetImageBlob(Handle, out size);
			var data = new byte[(ulong)size];
			Marshal.Copy(blob, data, 0, (int)size);
			return data;
		}

		uint getStorageSize(StorageType storage)
		{
			switch(storage)
			{
				case StorageType.Char: return 1u;
				case StorageType.Short: return 2u;
				case StorageType.Integer:
				case StorageType.Float: return 4u;
				case StorageType.Long:
				case StorageType.Double: return 8u;
				default: throw new ArgumentException("storage");
			}
		}

		public byte[] ExportImagePixels(long x, long y, ulong columns, ulong rows, string map, StorageType storage)
		{
			byte[] buffer = new byte[(long)rows * (long)columns * map.Length * getStorageSize(storage)];

			Test(Native.MagickExportImagePixels(Handle, (IntPtr)x, (IntPtr)y, (UIntPtr)columns, (UIntPtr)rows, map, storage, buffer));

			return buffer;
		}

		public byte[] ExportImagePixels(string map, StorageType storage)
		{
			return ExportImagePixels(0, 0, Width, Height, map, storage);
		}

		public ulong Width { get { return (ulong)Native.MagickGetImageWidth(Handle); } }
		public ulong Height { get { return (ulong)Native.MagickGetImageHeight(Handle); } }

		public void Resize(ulong columns, ulong rows, FilterType filter = FilterType.Undefined, double blur = 1)
		{
			Test(Native.MagickResizeImage(Handle, (UIntPtr)columns, (UIntPtr)rows, filter, blur));
		}

		public string ImageFormat { get { return Native.MagickGetImageFormat(Handle); } set { Native.MagickSetImageFormat(Handle, value); } }
		public ColorspaceType ImageColorspace { get { return Native.MagickGetImageColorspace(Handle); } set { Native.MagickSetImageColorspace(Handle, value); } }
		public ImageType ImageType { get { return Native.MagickGetImageType(Handle); } set { Native.MagickSetImageType(Handle, value); } }
	}
}
