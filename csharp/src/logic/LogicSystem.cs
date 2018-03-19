namespace ECSDemo
{
    class LogicSystem : ISystem
    {
        public void Tick()
        {
            double delta = TimeSystem.Elapsed.TotalSeconds;

            foreach (var e in EntityManager.Entities)
            {
                e.Walk((comp, name) => {
                    if (comp is ILogicComponent logicComp)
                        logicComp.Update(delta);
                });
            }
        }
    }
}