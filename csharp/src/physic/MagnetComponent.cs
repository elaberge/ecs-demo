namespace ECSDemo
{
    class MagnetComponent : BaseComponent
    {
        public double Charge { get; set; }

        public MagnetComponent(double charge)
        {
            Charge = charge;
        }

        public override string ToString()
        {
            return $"Magnet: charge={Charge}";
        }
    }
}