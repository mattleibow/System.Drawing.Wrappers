namespace System.Drawing
{
#if NETFX_CORE
    using global::Windows.UI;
#endif

    public class SolidBrush : Brush
    {
        public SolidBrush(Color c) : base(c)
        {
        }
    }
}