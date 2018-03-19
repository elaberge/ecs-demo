using System.Collections.Generic;

using CompDesc = System.Collections.Generic.KeyValuePair<string, ECSDemo.BaseComponent>;

namespace ECSDemo
{
    class Program
    {
        static void Main()
        {
            var systems = new List<ISystem> {
                new TimeSystem(),
                new PhysicSystem(),
                new LogicSystem(),
                new DebugSystem(),
            };

            var greeter = EntityManager.CreateEntity("greeter",
                                                     new CompDesc("hello", new HelloComponent())
                                                    );

            var mover = EntityManager.CreateEntity("mover",
                                                   new CompDesc("pos", new PositionComponent(new Point2D(5, 10))),
                                                   new CompDesc("move", new MotionComponent(new Vector2D(2, 1)))
                                                  );

            var attractor = EntityManager.CreateEntity("attractor",
                                                       new CompDesc("pos", new PositionComponent(new Point2D(20, 20))),
                                                       new CompDesc("move", new MotionComponent()),
                                                       new CompDesc("mass", new MassComponent(double.PositiveInfinity)),
                                                       new CompDesc("charge", new MagnetComponent(100))
                                                      );

            var floater = EntityManager.CreateEntity("floater",
                                                     new CompDesc("pos", new PositionComponent(new Point2D(25, 20))),
                                                     new CompDesc("move", new MotionComponent(new Vector2D(0, 2))),
                                                     new CompDesc("mass", new MassComponent(50)),
                                                     new CompDesc("charge", new MagnetComponent(-100))
                                                    );

            while (true)
            {
                foreach (var s in systems)
                    s.Tick();

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
