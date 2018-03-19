using System;

namespace ECSDemo
{
    class DebugSystem : ISystem
    {
        TimeSpan report;

        public void Tick()
        {
            report += TimeSystem.Elapsed;

            if (report < TimeSpan.FromSeconds(5))
                return;

            report = TimeSpan.Zero;
            Console.WriteLine("=== DEBUG ===");

            foreach (var e in EntityManager.Entities)
            {
                Console.WriteLine($"Entity {e.Name}");
                e.Walk((comp, name) => {
                    Console.WriteLine($"  {name,-10}: {comp.ToString()}");
                });
            }

            Console.WriteLine("=== END DEBUG ===");
        }
    }
}