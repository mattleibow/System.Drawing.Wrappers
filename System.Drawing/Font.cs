namespace System.Drawing
{
    using System;
#if NETFX_CORE
    using global::Windows.UI.Text;
    using global::Windows.UI.Xaml.Media;
#endif

    public class Font : IDisposable
    {
        public FontFamily FontFamily { get; set; }
        public int Size { get; set; }
        public FontStyle Style { get; set; }

        public Font(FontFamily family, int size, FontStyle style)
        {
            Size = size;
            FontFamily = family;
            Style = style;
        }

        public Font(FontFamily family, int size)
        {
            Size = size;
            FontFamily = family;
            Style = FontStyle.Normal;
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}