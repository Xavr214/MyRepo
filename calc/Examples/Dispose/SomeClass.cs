using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Examples.Dispose
{
    public class SomeClass : IDisposable
    {
        bool disposed = false;

        //unmanaged resources
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }

        ~SomeClass()
        {
            Dispose(false);
        }
    }
}
