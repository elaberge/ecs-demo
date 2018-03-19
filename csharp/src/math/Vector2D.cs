namespace ECSDemo
{
    struct Vector2D
    {
        public static Vector2D Zero = new Vector2D { x = 0, y = 0 };

        public double x;
        public double y;

        public double MagnitudeSq
        {
            get
            {
                return x * x + y * y;
            }
        }

        public double Magnitude
        {
            get {
                return System.Math.Sqrt(MagnitudeSq);
            }
        }

        public Vector2D Normalized
        {
            get {
                return this / Magnitude;
            }
        }

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x};{y})";
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.x + b.x, a.y + b.y);
        }

        public static Vector2D operator *(Vector2D v, double scale)
        {
            return new Vector2D(v.x * scale, v.y * scale);
        }

        public static Vector2D operator /(Vector2D v, double div)
        {
            double invDiv = 1.0 / div;
            return v * invDiv;
        }
    }
}