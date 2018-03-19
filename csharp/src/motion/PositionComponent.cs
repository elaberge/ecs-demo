namespace ECSDemo
{
    class PositionComponent : BaseComponent
    {
        public Point2D point;

        public PositionComponent(Point2D point)
        {
            this.point = point;
        }

        public override string ToString()
        {
            return $"Position: {point}";
        }
    }
}