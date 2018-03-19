using System;
using System.Collections.Generic;

namespace ECSDemo
{
    class Entity
    {
        public string Name { get; private set; }

        readonly Dictionary<string, BaseComponent> components = new Dictionary<string, BaseComponent>();

        public Entity(string name)
        {
            Name = name;
        }

        public void AddComponent<T>(T comp, string name = null) where T: BaseComponent
        {
            if (name == null)
                name = comp.GetType().Name;

            components.Add(name, comp);
            comp.Owner = this;
        }

        public T GetComponent<T>(string name) where T: BaseComponent
        {
            return components[name] as T;
        }

        public T FindComponentByType<T>() where T: BaseComponent
        {
            foreach (var item in components)
            {
                if (item.Value is T asT)
                    return asT;
            }
            return null;
        }

        public void Walk(Action<BaseComponent, string> walkFn)
        {
            foreach (var item in components)
                walkFn(item.Value, item.Key);
        }
    }
}