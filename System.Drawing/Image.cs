namespace System.Drawing
{
    using System;
#if NETFX_CORE
    using global::Windows.Foundation;
#endif

    public abstract class Image : IDisposable
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public Size Size
        {
            get { return new Size(Width, Height); }
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}