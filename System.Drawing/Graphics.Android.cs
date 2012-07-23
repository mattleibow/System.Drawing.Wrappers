namespace System.Drawing
{
    using System;
    using Android.Graphics;

    public class Graphics : IDisposable
    {
        private readonly bool ownCanvas;
        private readonly Paint paint;
        private readonly Canvas canvas;

        public PaintFlags Flags { get; set; }

        private Graphics()
        {
            this.paint = new Paint();
            this.Flags = PaintFlags.AntiAlias;
            this.ownCanvas = false;
        }

        private Graphics(Bitmap bitmap) 
            : this()
        {
            this.canvas = new Canvas(bitmap);
            this.ownCanvas = true;
        }

        public Graphics(Canvas canvas)
            : this()
        {
            this.canvas = canvas;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.paint.Dispose();
            
            if (this.ownCanvas)
            {
                this.canvas.Dispose();
            }
        }

        #endregion

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

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            this.paint.Color = pen.Color.ToAColor();
            this.paint.Flags = this.Flags;
            this.paint.SetStyle(Paint.Style.Stroke);
            this.paint.StrokeWidth = pen.Width;
            this.canvas.DrawLine(x1, y1, x2, y2, paint);
        }

        public void DrawRectangle(Pen pen, float x1, float y1, float w, float h)
        {
            this.paint.Color = pen.Color.ToAColor();
            this.paint.Flags = this.Flags;
            this.paint.SetStyle(Paint.Style.Stroke);
            this.paint.StrokeWidth = pen.Width;
            this.canvas.DrawRect(x1, y1, x1 + w, y1 + h, this.paint);
        }

        public void DrawEllipse(Pen pen, float x, float y, float w, float h)
        {
            this.paint.Color = pen.Color.ToAColor();
            this.paint.Flags = this.Flags;
            this.paint.SetStyle(Paint.Style.Stroke);
            this.paint.StrokeWidth = pen.Width;
            using (RectF r = new RectangleF(x, y, w, h).ToRectF())
            {
                this.canvas.DrawOval(r, this.paint);
            }
        }

        public void FillRectangle(Brush brush, float x1, float y1, float w, float h)
        {
            this.paint.Color = brush.Color.ToAColor();
            this.paint.Flags = this.Flags;
            this.paint.SetStyle(Paint.Style.Fill);
            this.canvas.DrawRect(x1, y1, x1 + w, y1 + h, this.paint);
        }

        public void FillRectangle(Brush brush, RectangleF rect)
        {
            this.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void FillRectangle(Brush brush, Rectangle rect)
        {
            this.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void FillEllipse(Brush brush, RectangleF rect)
        {
            this.FillEllipse(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void FillEllipse(Brush brush, Rectangle rect)
        {
            this.FillEllipse(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void FillEllipse(Brush brush, float x, float y, float w, float h)
        {
            this.paint.Color = brush.Color.ToAColor();
            this.paint.Flags = this.Flags;
            this.paint.SetStyle(Paint.Style.Fill);
            using (RectF r = new RectangleF(x, y, w, h).ToRectF())
            {
                this.canvas.DrawOval(r, this.paint);
            }
        }

        public void DrawString(string text, Font font, Brush brush, float x, float y)
        {
            this.paint.Color = brush.Color.ToAColor();
            this.paint.Flags = PaintFlags.AntiAlias;

            this.paint.TextSize = font.Size;
            this.paint.SetTypeface(font.FontFamily.Typeface);
            this.paint.SetStyle(Paint.Style.Fill);

            using (var fm = this.paint.GetFontMetrics())
            {
                this.canvas.DrawText(text, x, y - (fm.Top + fm.Bottom), this.paint);
            }
        }

        public void DrawString(string text, Font font, Brush brush, System.Drawing.PointF pos)
        {
            this.DrawString(text, font, brush, pos.X, pos.Y);
        }

        public void DrawString(string text, Font font, Brush brush, RectangleF rect)
        {
            this.DrawString(text, font, brush, rect.Location);
        }

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

        public void RotateTransform(float angle)
        {
            this.canvas.Rotate(angle);
        }

        public void TranslateTransform(float x, float y)
        {
            this.canvas.Translate(x, y);
        }

        public void Clear()
        {
            this.Clear(Color.Transparent);
        }

        public void Clear(Color fill)
        {
            this.canvas.DrawARGB(fill.A, fill.R, fill.G, fill.B);
        }
    }
}