namespace System.Drawing
{
    using System;
#if NETFX_CORE
    using global::Windows.UI;
#endif

    public class Brush : IDisposable
    {
        public Color Color { get; set; }

        protected Brush(Color c)
        {
            Color = c;
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}