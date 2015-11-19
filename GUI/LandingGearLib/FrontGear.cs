using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LandingGearLib
{
    public class FrontGear : Cylinder
    {
        public FrontGear(string location) : base(location)
        {
            Is_Locked = true;
            uidp = 8;
            fdthp = 16;
            lihp = 4;
            uihp = 8;
            fhtdp = 12;
            lidp = 4;
        }
     
    }

    public class SideGear : Cylinder
    {
        public SideGear(string location) : base(location)
        {
            Is_Locked = true;
            uidp = 8;
            fdthp = 20;
            lihp = 4;
            uihp = 8;
            fhtdp = 16;
            lidp = 4;
        }
    }

    public class FrontDoor : Cylinder
    {
        public FrontDoor(string location) : base(location)
        {
            Is_Locked = true;
            uidp = 0;
            fdthp = 12;
            lihp = 3;
            uihp = 4;
            fhtdp = 12;
            lidp = 0;
        }
    }
    public class SideDoor : Cylinder
    {
        public SideDoor(string location) : base(location)
        {
            Is_Locked = true;
            uidp = 0;
            fdthp = 16;
            lihp = 3;
            uihp = 4;
            fhtdp = 15;
            lidp = 0;
        }
    }
}
