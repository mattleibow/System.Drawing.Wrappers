namespace System.Drawing
{
    using global::Windows.Foundation;
    using global::Windows.UI;
    using global::Windows.UI.Xaml;
    using global::Windows.UI.Xaml.Shapes;

    public static partial class DrawingExtensions
    {
        #region Public Methods and Operators

        public static Rectangle CenterIn(this Rectangle smallRect, Rectangle bigRect)
        {
            double width = (bigRect.Width - smallRect.Width) / 2;
            double height = (bigRect.Height - smallRect.Height) / 2;

            double left = bigRect.Margin.Left + width;
            double top = bigRect.Margin.Top + height;

            return new Rectangle
                       {
                           Margin = new Thickness(left, top, 0, 0),
                           Width = smallRect.Width,
                           Height = smallRect.Height
                       };
        }

        public static double CenterX(this Rectangle rectangle)
        {
            return rectangle.Margin.Left + (rectangle.Width / 2);
        }

        public static double CenterY(this Rectangle rectangle)
        {
            return rectangle.Margin.Top + (rectangle.Height / 2);
        }

        public static Size FitInSize(this Size sizeToFit, Size sizeInWhich)
        {
            return sizeToFit.FitInSize(sizeInWhich.Width, sizeInWhich.Height);
        }

        public static Size FitInSize(this Size sizeToFit, double width, double height)
        {
            double w = width / sizeToFit.Width;
            double h = height / sizeToFit.Height;

            double most = Math.Min(w, h);
            double shrink = Math.Min(most, 1F);

            return new Size(sizeToFit.Width * shrink, sizeToFit.Height * shrink);
        }

        public static Size FitInSize(this Size sizeToFit, int width, int height)
        {
            double w = width / sizeToFit.Width;
            double h = height / sizeToFit.Height;

            double most = Math.Min(w, h);
            double shrink = Math.Min(most, 1F);

            double newWidth = sizeToFit.Width * shrink;
            double newHeight = sizeToFit.Height * shrink;

            return new Size((int)newWidth, (int)newHeight);
        }

        public static Color MakeOpaque(this Color systemColor)
        {
            return Color.FromArgb(byte.MaxValue, systemColor.R, systemColor.G, systemColor.B);
        }

        #endregion
    }
}
