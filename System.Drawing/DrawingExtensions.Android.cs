namespace System.Drawing
{
    using Android.Graphics;

    public static partial class DrawingExtensions
    {
        public static RectF ToRectF(this RectangleF systemRectangle)
        {
            return new RectF(systemRectangle.Left,
                             systemRectangle.Top,
                             systemRectangle.Right,
                             systemRectangle.Bottom);
        }

        public static Rect ToRect(this RectangleF systemRectangle)
        {
            return new Rect((int)systemRectangle.Left,
                             (int)systemRectangle.Top,
                             (int)systemRectangle.Right,
                             (int)systemRectangle.Bottom);
        }

        public static Rectangle ToRectangle(this RectangleF systemRectangle)
        {
            return new Rectangle((int)systemRectangle.Left,
                                 (int)systemRectangle.Top,
                                 (int)systemRectangle.Width,
                                 (int)systemRectangle.Height);
        }

        public static Rectangle CenterIn(this Rectangle smallRect, Rectangle bigRect)
        {
            var width = (bigRect.Width - smallRect.Width) / 2;
            var height = (bigRect.Height - smallRect.Height) / 2;

            return new Rectangle(bigRect.Left + width,
                                 bigRect.Top + height,
                                 smallRect.Width,
                                 smallRect.Height);
        }

        public static Rect ToRect(this RectF androidRect)
        {
            return new Rect((int)androidRect.Left,
                            (int)androidRect.Top,
                            (int)androidRect.Right,
                            (int)androidRect.Bottom);
        }

        public static Rectangle ToRectangle(this Rect androidRect)
        {
            return new Rectangle(androidRect.Left,
                                 androidRect.Top,
                                 androidRect.Width(),
                                 androidRect.Height());
        }

        public static RectangleF ToRectangleF(this RectF androidRect)
        {
            return new RectangleF(androidRect.Left,
                                  androidRect.Top,
                                  androidRect.Width(),
                                  androidRect.Height());
        }

        public static Rect ToRect(this Rectangle systemRectangle)
        {
            return new Rect(systemRectangle.Left,
                            systemRectangle.Top,
                            systemRectangle.Right,
                            systemRectangle.Bottom);
        }

        public static int CenterX(this Rectangle rectangle)
        {
            return (rectangle.Left + rectangle.Right) / 2;
        }

        public static float CenterX(this RectangleF rectangle)
        {
            return (rectangle.Left + rectangle.Right) / 2F;
        }

        public static Color MakeOpaque(this Color systemColor)
        {
            return Color.FromArgb(systemColor.R, systemColor.G, systemColor.B);
        }

        public static Android.Graphics.Color ToAColor(this Color systemColor)
        {
            return new Android.Graphics.Color(systemColor.ToArgb());
        }

        public static Color ToColor(this Android.Graphics.Color androidColor)
        {
            return Color.FromArgb(androidColor.ToArgb());
        }

        public static SizeF FitInSize(this Size sizeToFit, Size sizeInWhich)
        {
            return sizeToFit.FitInSize(sizeInWhich.Width, sizeInWhich.Height);
        }

        public static SizeF FitInSize(this SizeF sizeToFit, float width, float height)
        {
            var w = width / sizeToFit.Width;
            var h = height / sizeToFit.Height;

            var most = System.Math.Min(w, h);
            var shrink = System.Math.Min(most, 1F);

            return new SizeF(sizeToFit.Width * shrink, sizeToFit.Height * shrink);
        }

        public static Size FitInSize(this Size sizeToFit, int width, int height)
        {
            var w = (float)width / sizeToFit.Width;
            var h = (float)height / sizeToFit.Height;

            var most = System.Math.Min(w, h);
            var shrink = System.Math.Min(most, 1F);

            var newWidth = sizeToFit.Width * shrink;
            var newHeight = sizeToFit.Height * shrink;

            return new Size((int)newWidth, (int)newHeight);
        }

        public static SizeF FitInSize(this SizeF sizeToFit, int width, int height)
        {
            return sizeToFit.FitInSize((float)width, height);
        }
    }
}