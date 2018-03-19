namespace ECSDemo
{
    class MotionComponent : BaseComponent
    {
        public Vector2D speed;

        public MotionComponent()
            : this(Vector2D.Zero)
        {
        }

        public MotionComponent(Vector2D speed)
        {
            this.speed = speed;
        }

        public override string ToString()
        {
            return $"Motion: {speed}";
        }
    }
}