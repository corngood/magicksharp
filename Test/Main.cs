using System;
using System.Runtime.InteropServices;

using MagickCore;
using MagickWand;

namespace Test
{
	class MainClass
	{
		public unsafe static void Main(string[] args)
		{
			using(var wand = new MagickWand.Wand())
			{
				using(var background = new MagickWand.PixelWand())
				{
					background.Red = 1;
					background.Opacity = 0.5;
					wand.NewImage(16, 16, background);
					wand.ImageType = ImageType.TrueColorMatte;
				}

				var data = wand.ExportImagePixels("RGBA", StorageType.Char);

				data = System.IO.File.ReadAllBytes("/home/david/p4/tech/source/engine/data/images/placeholder.png");

				wand.ReadImage(data);

				var blah = wand.GetImageBlob();

				System.IO.File.WriteAllBytes("/home/david/test2.png", blah);

				wand.ReadImage("/home/david/p4/tech/source/engine/data/images/placeholder.png");
				wand.WriteImage("/home/david/test.png");
			}
			/*var exception = NativeMethods.AcquireExceptionInfo();
			var info = NativeMethods.AcquireImageInfo();

			var s = sizeof(Image);

			var r = NativeMethods.CopyMagickString(&info->filename, "/home/david/p4/tech/source/engine/data/images/placeholder.png", (UIntPtr)Constants.MaxTextExtent);
			var ii = *info;

			var image = NativeMethods.ReadImage(info, exception);
			var i = *image;

			var e = *exception;

			NativeMethods.DestroyImage(image);

			Console.WriteLine(i);*/
		}
	}
}
