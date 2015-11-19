using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingGearLib
{
    public class GlobalValve
    {
        public List<ElectroValve> Valves { get;}
        public bool Pressurized { get; set; }

        public GlobalValve()
        {
            Pressurized = true;
            Valves = new List<ElectroValve>();
        }

        public void StartStimulate()
        {
            if (Pressurized)
            {
                Valves.ForEach(v => v.Pressurized = true);

                System.Threading.Thread.Sleep(200);
            }
        }

        public void EndStimulate()
        {
            System.Threading.Thread.Sleep(1000);

            Valves.ForEach(v => v.Pressurized = false);

        }
    }
}
