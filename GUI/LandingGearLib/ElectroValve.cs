using System.Collections.Generic;

namespace LandingGearLib
{
    public class ElectroValve
    {
        public enum Types
        {
            Retraction,
            Extension
        }

        public enum Targets
        {
            Doors,
            Gears
        }
        public List<Cylinder> Cylinders { get; }

        public ElectroValve(Targets target, Types type , bool pressurized)
        {
            Target = target;
            Type = type;
            Pressurized = pressurized;
            Cylinders = new List<Cylinder>();
        }

        public Targets Target { get; }
        public Types Type { get; }
        public bool Pressurized { get; set; }

        public void StartStimulate()
        {
            if (Pressurized)
            {
                if (Type == Types.Retraction)
                {
                    foreach (var cylinder in Cylinders)
                    {
                        cylinder.Retract();
                    }
                }
                else if (Type == Types.Extension)
                {
                    foreach (var cylinder in Cylinders)
                    {
                        cylinder.Extend();
                    }
                }
            }
        }

        public void EndStimulate()
        {
                if (Type == Types.Retraction)
                {
                    foreach (var cylinder in Cylinders)
                    {
                        cylinder.StopRetract();
                    }
                }
                else if (Type == Types.Extension)
                {
                    foreach (var cylinder in Cylinders)
                    {
                        cylinder.StopExtend();
                    }
                }
        }
    }
}