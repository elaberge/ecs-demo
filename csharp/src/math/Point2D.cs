namespace ECSDemo
{
    struct Point2D
    {
        public static Point2D Zero = new Point2D { x = 0, y = 0 };

        public double x;
        public double y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x};{y})";
        }

        public static Point2D operator + (Point2D p, Vector2D v)
        {
            return new Point2D(p.x + v.x, p.y + v.y);
        }

        public static Vector2D operator -(Point2D a, Point2D b)
        {
            return new Vector2D(a.x - b.x, a.y - b.y);
        }
    }
}