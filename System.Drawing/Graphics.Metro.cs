namespace System.Drawing
{
    using global::Windows.Foundation;
    using global::Windows.UI;
    using global::Windows.UI.Xaml;
    using global::Windows.UI.Xaml.Controls;
    using global::Windows.UI.Xaml.Media;
    using global::Windows.UI.Xaml.Shapes;

    public class Graphics : IDisposable
    {
        private readonly Canvas canvas;

        /*
        private Graphics(Bitmap bitmap) 
            : this()
        {
            this.canvas = new Canvas(bitmap);
            this.ownCanvas = true;
        }
        */

        public Graphics(Canvas canvas)
            : this()
        {
            this.canvas = canvas;
        }

        private Graphics()
        {
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        public void DrawEllipse(Pen pen, double x, double y, double w, double h)
        {
            canvas.Children.Add(Shapes.CreateEllipse(x, y, w, h).SetPen(pen));
        }

        /*
        public static Graphics FromBitmap(Bitmap bitmap)
        {
            return new Graphics(bitmap);
        }

        public void DrawImage(Bitmap bitmap, Rectangle target, Rectangle source, GraphicsUnit gu)
        {
            this.paint.Flags = 0;
            using (Rect sa = source.ToRect())
            using (Rect ta = target.ToRect())
            {
                this.canvas.DrawBitmap(bitmap, sa, ta, this.paint);
            }
        }

        public void DrawImage(Bitmap bitmap, int x, int y)
        {
            this.paint.Flags = 0;
            this.canvas.DrawBitmap(bitmap, x, y, this.paint);
        }

        public void DrawImage(Bitmap bitmap, int x, int y, Rectangle source, GraphicsUnit gu)
        {
            this.DrawImage(bitmap, new Rectangle(x, y, bitmap.Width, bitmap.Height), source, gu);
        }
        */

        public void DrawLine(Pen pen, double x1, double y1, double x2, double y2)
        {
            var line = new Line
                           {
                               Stroke = new SolidColorBrush(pen.Color),
                               StrokeThickness = pen.Width,
                               X1 = x1,
                               Y1 = y1,
                               X2 = x2,
                               Y2 = y2
                           };
            canvas.Children.Add(line);
        }

        public void DrawRectangle(Pen pen, double x, double y, double w, double h)
        {
            canvas.Children.Add(Shapes.CreateRectangle(x, y, w, h).SetPen(pen));
        }

        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            DrawRectangle(pen, rect.Margin.Left, rect.Margin.Top, rect.Width, rect.Height);
        }

        public void DrawString(string text, Font font, Brush brush, double x, double y)
        {
            var label = new TextBlock
                            {
                                Text = text,
                                FontFamily = font.FontFamily,
                                FontSize = font.Size,
                                FontStyle = font.Style,
                                Foreground = new SolidColorBrush(brush.Color),
                                Margin = new Thickness(x, y, 0, 0)
                            };
            canvas.Children.Add(label);
        }

        public void DrawString(string text, Font font, Brush brush, Point pos)
        {
            DrawString(text, font, brush, pos.X, pos.Y);
        }

        public void DrawString(string text, Font font, Brush brush, Rectangle rect)
        {
            DrawString(text, font, brush, new Point(rect.Margin.Left, rect.Margin.Top));
        }

        public void FillEllipse(Brush brush, Rectangle rect)
        {
            FillEllipse(brush, rect.Margin.Left, rect.Margin.Top, rect.Width, rect.Height);
        }

        public void FillEllipse(Brush brush, double x, double y, double w, double h)
        {
            canvas.Children.Add(Shapes.CreateEllipse(x, y, w, h).SetBrush(brush));
        }

        public void FillRectangle(Brush brush, double x, double y, double w, double h)
        {
            canvas.Children.Add(Shapes.CreateRectangle(x, y, w, h).SetBrush(brush));
        }

        public void FillRectangle(Brush brush, Rectangle rect)
        {
            FillRectangle(brush, rect.Margin.Left, rect.Margin.Top, rect.Width, rect.Height);
        }

        /*
        public Size MeasureString(string text, Font font)
        {
            using (var p = new Paint(this.paint))
            using (var bounds = new Rect())
            using (var fm = p.GetFontMetrics())
            {
                p.TextSize = font.Size;
                p.SetTypeface(font.FontFamily.Typeface);
                p.SetStyle(Paint.Style.Stroke);

                p.GetTextBounds(text, 0, text.Length, bounds);
                var width = bounds.Width();
                var height = -fm.Top + fm.Bottom;

                return new SizeF(width, height).ToSize();
            }
        }
        */
        
        /*
        public void RotateTransform(double angle)
        {
            this.canvas.Rotate(angle);
        }

        public void TranslateTransform(double x, double y)
        {
            this.canvas.Translate(x, y);
        }
        */
        public void Clear()
        {
            Clear(Colors.Transparent);
        }

        public void Clear(Color fill)
        {
            canvas.Children.Clear();
            canvas.Background = new SolidColorBrush(fill);
        }
    }
}