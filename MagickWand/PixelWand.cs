using System;
using System.Runtime.InteropServices;

namespace MagickWand
{
	public class PixelWand : NativeObject
	{
		static class Native
		{
			[DllImport(Library)] public static extern IntPtr NewPixelWand();
			[DllImport(Library)] public static extern IntPtr DestroyPixelWand(IntPtr pixelWand);
			[DllImport(Library)] public static extern string PixelGetColorAsString(IntPtr pixelWand);
			[DllImport(Library)] public static extern string PixelGetColorAsNormalizedString(IntPtr pixelWand);
			[DllImport(Library)] public static extern double PixelGetRed(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetRed(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetGreen(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetGreen(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetBlue(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetBlue(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetAlpha(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetAlpha(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetCyan(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetCyan(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetMagenta(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetMagenta(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetYellow(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetYellow(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetBlack(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetBlack(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetOpacity(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetOpacity(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern double PixelGetFuzz(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetFuzz(IntPtr pixelWand, double value);
			[DllImport(Library)] public static extern UIntPtr PixelGetColorCount(IntPtr pixelWand);
			[DllImport(Library)] public static extern void PixelSetColorCount(IntPtr pixelWand, UIntPtr count);
		}
		
		public PixelWand() : base(Native.NewPixelWand())
		{
		}
		
		protected override void Dispose(bool disposing)
		{
			Native.DestroyPixelWand(Handle);
		}

		public override string ToString()
		{
			return Native.PixelGetColorAsString(Handle);
		}

		public string ToNormalizedString()
		{
			return Native.PixelGetColorAsNormalizedString(Handle);
		}

		public double Red { get { return Native.PixelGetRed(Handle); } set { Native.PixelSetRed(Handle, value); } }
		public double Green { get { return Native.PixelGetGreen(Handle); } set { Native.PixelSetGreen(Handle, value); } }
		public double Blue { get { return Native.PixelGetBlue(Handle); } set { Native.PixelSetBlue(Handle, value); } }
		public double Alpha { get { return Native.PixelGetBlack(Handle); } set { Native.PixelSetBlack(Handle, value); } }

		public double Cyan { get { return Native.PixelGetCyan(Handle); } set { Native.PixelSetCyan(Handle, value); } }
		public double Magenta { get { return Native.PixelGetMagenta(Handle); } set { Native.PixelSetMagenta(Handle, value); } }
		public double Yellow { get { return Native.PixelGetYellow(Handle); } set { Native.PixelSetYellow(Handle, value); } }
		public double Opacity { get { return Native.PixelGetOpacity(Handle); } set { Native.PixelSetOpacity(Handle, value); } }

		public double Fuzz { get { return Native.PixelGetFuzz(Handle); } set { Native.PixelSetFuzz(Handle, value); } }

		public ulong ColorCount { get { return (ulong)Native.PixelGetColorCount(Handle); } set { Native.PixelSetColorCount(Handle, (UIntPtr)value); } }
	}
}

