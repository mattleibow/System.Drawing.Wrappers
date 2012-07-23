namespace System.Drawing
{
    public struct Padding
    {
        public Padding(int padding)
            : this(padding, padding)
        {
        }

        public Padding(int leftRight, int topBottom)
            : this(leftRight, leftRight, topBottom, topBottom)
        {
        }

        public Padding(int left, int right, int top, int bottom)
            : this()
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

        public int Horizontal { get { return Left + Right; } }
        public int Vertical { get { return Top + Bottom; } }
    }
}