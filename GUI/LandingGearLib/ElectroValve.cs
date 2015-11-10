using System.Collections.Generic;

namespace LandingGearLib
{
    public class ElectroValve
    {
        private List<Cylinder> cylinders;

        public ElectroValve(string location, string type, bool on)
        {
            Location = location;
            Type = type;
            On = on;
        }

        public string Location { get; }
        public string Type { get; }
        public bool On { get; set; }

        public void Update()
        {
            if (!On) return;
            if (Type == "Retraction")
            {
                foreach (var cylinder in cylinders)
                {
                    cylinder.Retract();
                }
            }
            else if (Type == "Extension")
            {
                foreach (var cylinder in cylinders)
                {
                    cylinder.Extend();
                }
            }
        }
    }
}