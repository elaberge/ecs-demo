using System;

namespace ECSDemo
{
    class HelloComponent : BaseComponent, ILogicComponent
    {
        double elapsed;
        int count;

        public void Update(double delta)
        {
            elapsed += delta;
            if (elapsed > 1.0)
            {
                count++;
                elapsed -= 1.0;
                Console.WriteLine($"Hello #{count}!");
            }
        }

        public override string ToString()
        {
            return $"Hello: count={count}, elapsed={elapsed}";
        }
    }
}