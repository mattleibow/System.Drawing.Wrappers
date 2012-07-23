namespace System.Drawing
{
    public static class Shapes
    {
        #region Public Methods and Operators

        public static Rectangle CreateEllipse(int x, int y, int w, int h)
        {
            return CreateRectangle(x, y, w, h);
        }

        public static Rectangle CreateRectangle(int x, int y, int w, int h)
        {
            return new Rectangle(x, y, w, h);
        }

        #endregion
    }
}