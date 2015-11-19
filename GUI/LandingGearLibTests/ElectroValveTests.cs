using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandingGearLib;
using NUnit.Framework;

namespace LandingGearLibTests
{
    [TestFixture]
    class ElectroValveTests
    {
        [Test]
        public void ElectroValveWithCylindersCanCloseThem()
        {
            ElectroValve valve = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Retraction, true);

            valve.Cylinders.Add(new FrontGear("Front",Cylinder.Targets.Gears));
            valve.Cylinders.Add(new SideGear("Left",Cylinder.Targets.Gears));
            valve.Cylinders.Add(new SideGear("Right",Cylinder.Targets.Gears));

            foreach (var cylinder in valve.Cylinders)
            {
                Assert.IsTrue(cylinder.Is_Locked);
                Assert.IsTrue(cylinder.Gear_Extended);
            }

            valve.StartStimulate();

           System.Threading.Thread.Sleep(4000);

            foreach (var cylinder in valve.Cylinders)
            {
                Assert.IsTrue(cylinder.Is_Locked);
                Assert.IsTrue(cylinder.Gear_retracted);
            }
        }

        [Test]
        public void ElectroValveWithCylindersCanOpenThem()
        {
            ElectroValve valve = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Retraction, true);
            ElectroValve valveOpen = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Extension, true);

            valve.Cylinders.Add(new FrontGear("Front",Cylinder.Targets.Gears));
            valve.Cylinders.Add(new SideGear("Left",Cylinder.Targets.Gears));
            valve.Cylinders.Add(new SideGear("Right",Cylinder.Targets.Gears));

            foreach (var cylinder in valve.Cylinders)
            {
                valveOpen.Cylinders.Add(cylinder);
            }

            foreach (var cylinder in valve.Cylinders)
            {
                Assert.IsTrue(cylinder.Is_Locked);
                Assert.IsTrue(cylinder.Gear_Extended);
            }

            valve.StartStimulate();

            System.Threading.Thread.Sleep(4000);

           
            valve.EndStimulate();

            foreach (var cylinder in valve.Cylinders)
            {
                Assert.IsTrue(cylinder.Is_Locked);
                Assert.IsTrue(cylinder.Gear_retracted);
            }

            valveOpen.StartStimulate();

            System.Threading.Thread.Sleep(4000);

            foreach (var cylinder in valve.Cylinders)
            {
                Assert.IsTrue(cylinder.Is_Locked);
                Assert.IsTrue(cylinder.Gear_Extended);
            }

        }
    }
}
