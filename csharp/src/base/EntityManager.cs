using System.Collections.Generic;

namespace ECSDemo
{
    static class EntityManager
    {
        static readonly Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public static IEnumerable<Entity> Entities
        {
            get { return entities.Values; }
        }

        public static Entity CreateEntity(string name, params KeyValuePair<string, BaseComponent>[] components)
        {
            var newEntity = new Entity(name);
            entities.Add(name, newEntity);
            foreach (var items in components)
                newEntity.AddComponent(items.Value, items.Key);
            return newEntity;
        }
    }
}