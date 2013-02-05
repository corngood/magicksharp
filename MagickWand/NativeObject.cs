using System;
using System.Runtime.InteropServices;

namespace MagickWand
{
	public abstract class NativeObject : IDisposable
	{
		protected const string Library = "MagickWand";

		protected void Test(bool result)
		{
			if(!result) throw new WandException();
		}
		
		internal readonly IntPtr Handle;
		
		public NativeObject(IntPtr handle)
		{
			Handle = handle;
		}
		
		protected abstract void Dispose(bool disposing);

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		~NativeObject()
		{
			Dispose(false);
		}
	}
}

