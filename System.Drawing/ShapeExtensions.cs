namespace System.Drawing
{
    using global::Windows.UI.Xaml.Media;
    using global::Windows.UI.Xaml.Shapes;

    public static class ShapeExtensions
    {
        #region Public Methods and Operators

        public static T SetBrush<T>(this T shape, Brush brush) where T : Shape
        {
            shape.Fill = new SolidColorBrush(brush.Color);

            return shape;
        }

        public static T SetPen<T>(this T shape, Pen pen) where T : Shape
        {
            shape.Stroke = new SolidColorBrush(pen.Color);
            shape.StrokeThickness = pen.Width;

            return shape;
        }

        #endregion
    }
}