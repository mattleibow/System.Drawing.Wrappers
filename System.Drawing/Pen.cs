namespace System.Drawing
{
    using System;
#if NETFX_CORE
    using global::Windows.UI;
#endif

    public class Pen : IDisposable
    {
        public Color Color { get; set; }
        public float Width { get; set; }

        public Pen(Color c)
        {
            Color = c;
            Width = 1;
        }

        public Pen(Color c, float width)
        {
            Color = c;
            Width = width;
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}