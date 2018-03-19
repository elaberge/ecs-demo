namespace ECSDemo
{
    class MassComponent : BaseComponent
    {
        public double Mass { get; set; }

        public MassComponent(double mass)
        {
            Mass = mass;
        }

        public override string ToString()
        {
            return $"Mass: mass={Mass}";
        }
    }
}