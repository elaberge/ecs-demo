using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ECSDemo
{
    class PhysicSystem : ISystem
    {
        struct AccelMassInfo
        {
            public MassComponent mass;
            public PositionComponent pos;
            public MotionComponent motion;
        }

        TimeSpan step = TimeSpan.FromMilliseconds(1);
        TimeSpan remaining = TimeSpan.Zero;
                                
        public void Tick()
        {
            var motionComps = new List<MotionComponent>();
            var magnetComps = new List<MagnetComponent>();

            foreach (var e in EntityManager.Entities)
            {
                e.Walk((comp, name) => {
                    if (comp is MotionComponent motion)
                        motionComps.Add(motion);
                    if (comp is MagnetComponent magnet)
                        magnetComps.Add(magnet);
                });
            }

            remaining += TimeSystem.Elapsed;
            while (remaining >= step)
            {
                Accelerate(magnetComps);
                Move(motionComps);
                remaining -= step;
            }
        }

        void Accelerate(List<MagnetComponent> magnetComps)
        {
            double delta = step.TotalSeconds;

            var objProps = new Dictionary<MagnetComponent, AccelMassInfo>();

            foreach (var m in magnetComps)
            {
                var massComp = m.Owner.FindComponentByType<MassComponent>();
                var posComp = m.Owner.FindComponentByType<PositionComponent>();
                var motionComp = m.Owner.FindComponentByType<MotionComponent>();
                Debug.Assert(massComp != null);
                Debug.Assert(posComp != null);
                Debug.Assert(motionComp != null);

                objProps[m] = new AccelMassInfo{ mass = massComp, pos = posComp, motion = motionComp };
            }

            foreach (var m in magnetComps)
            {
                Vector2D netForce = Vector2D.Zero;

                var props = objProps[m];

                foreach (var m2 in magnetComps)
                {
                    if (m == m2)
                        continue;

                    var otherProps = objProps[m2];
                    Vector2D distVec = props.pos.point - otherProps.pos.point;
                    double distSq = distVec.MagnitudeSq;
                    double charge = m.Charge * m2.Charge;
                    double force = charge / distSq;
                    netForce += distVec.Normalized * force;
                }

                Vector2D accel = netForce / props.mass.Mass;
                props.motion.speed += accel * delta;
            }
        }

        void Move(List<MotionComponent> motionComps)
        {
            double delta = step.TotalSeconds;
            foreach (var m in motionComps)
            {
                var posComp = m.Owner.FindComponentByType<PositionComponent>();
                Debug.Assert(posComp != null);

                posComp.point += m.speed * delta;
            }
        }
    }
}