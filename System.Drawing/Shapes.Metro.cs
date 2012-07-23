namespace System.Drawing
{
    using global::Windows.UI.Xaml;
    using global::Windows.UI.Xaml.Shapes;

    public static class Shapes
    {
        #region Public Methods and Operators

        public static Ellipse CreateEllipse(double x, double y, double w, double h)
        {
            double x2 = x + w;
            double y2 = y + h;
            var ellipse = new Ellipse
                { Margin = new Thickness(x, y, x2, y2), Width = Math.Abs(x2 - x), Height = Math.Abs(y2 - y) };
            return ellipse;
        }

        public static Rectangle CreateRectangle(double x, double y, double w, double h)
        {
            double x2 = x + w;
            double y2 = y + h;
            var rect = new Rectangle
                { Margin = new Thickness(x, y, x2, y2), Width = Math.Abs(x2 - x), Height = Math.Abs(y2 - y) };
            return rect;
        }

        #endregion
    }
}