using System;

namespace Store.Data
{
    public class DisposableBase : IDisposable
    {
        private bool IsDisposed;

        ~DisposableBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                DisposeCore();
            }
            IsDisposed = true;
        }

        // this dispose shoud be overrided for the custom clases
        protected virtual void DisposeCore()
        {
            
        }
    }
}