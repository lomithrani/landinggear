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
    public class CylinderTests
    {
        [Test]
        public void FrontGearTakesCloseTo2s8ToClose()
        {
            var frontGear = new FrontGear("Front", Cylinder.Targets.Gears);

            var start = DateTime.Now;
            frontGear.Retract();

            while (!(frontGear.Is_Locked && frontGear.Gear_retracted))
            {
                
            }
            var end = DateTime.Now;

            var dif = end - start;
            var expected = 2.8;

            var variation = Math.Abs((dif.TotalSeconds - expected)/expected);
          
            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void FrontGearTakesCloseTo2s4ToOpen()
        {
            var frontGear = new FrontGear("Front",Cylinder.Targets.Gears);

       
            frontGear.Retract();

            while (!(frontGear.Is_Locked && frontGear.Gear_retracted))
            {

            }
            
            frontGear.StopRetract();

            var start = DateTime.Now;
            frontGear.Extend();

            while (!(frontGear.Is_Locked && frontGear.Gear_Extended))
            {
                
            }
            var end = DateTime.Now;
            var dif = end - start;
            var expected = 2.4;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void SideGearTakesCloseTo3s2ToClose()
        {
            var sideGear = new SideGear("Left",Cylinder.Targets.Gears);

            var start = DateTime.Now;
            sideGear.Retract();

            while (!(sideGear.Is_Locked && sideGear.Gear_retracted))
            {

            }
            var end = DateTime.Now;

            var dif = end - start;
            var expected = 3.2;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void SideGearTakesCloseTo2s8ToOpen()
        {
            var sideGear = new SideGear("Right",Cylinder.Targets.Gears);


            sideGear.Retract();

            while (!(sideGear.Is_Locked && sideGear.Gear_retracted))
            {

            }

            sideGear.StopRetract();

            var start = DateTime.Now;
            sideGear.Extend();

            while (!(sideGear.Is_Locked && sideGear.Gear_Extended))
            {

            }
            var end = DateTime.Now;
            var dif = end - start;
            var expected = 2.8;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void FrontDoorTakesCloseTo1s6ToOpen()
        {
            var frontDoor = new FrontDoor("Front",Cylinder.Targets.Doors);

            var start = DateTime.Now;
            frontDoor.Extend();

            while (!(frontDoor.Is_Locked && frontDoor.Gear_Extended))
            {

            }
            var end = DateTime.Now;

            var dif = end - start;
            var expected = 1.6;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void FrontDoorTakesCloseTo156ToClose()
        {
            var frontDoor = new FrontDoor("Front",Cylinder.Targets.Doors);


            frontDoor.Retract();

            while (!(frontDoor.Is_Locked && frontDoor.Gear_retracted))
            {

            }

            frontDoor.StopRetract();

            var start = DateTime.Now;
            frontDoor.Extend();

            while (!(frontDoor.Is_Locked && frontDoor.Gear_Extended))
            {

            }
            var end = DateTime.Now;
            var dif = end - start;
            var expected = 1.6;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void SideDoorTakesCloseTo1s9ToClose()
        {
            var sideDoor = new SideDoor("Right",Cylinder.Targets.Doors);

            sideDoor.Extend();

            while (!(sideDoor.Is_Locked && sideDoor.Gear_Extended))
            {

            }

            sideDoor.StopExtend();

            var start = DateTime.Now;
            sideDoor.Retract();

            while (!(sideDoor.Is_Locked && sideDoor.Gear_retracted))
            {

            }
            var end = DateTime.Now;

            var dif = end - start;
            var expected = 1.9;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }

        [Test]
        public void SideDoorTakesCloseTo1s9ToOpen()
        {
            var sideDoor = new SideDoor("Left",Cylinder.Targets.Doors);

            var start = DateTime.Now;
            sideDoor.Extend();

            while (!(sideDoor.Is_Locked && sideDoor.Gear_Extended))
            {

            }
            var end = DateTime.Now;
            var dif = end - start;
            var expected = 1.9;

            var variation = Math.Abs((dif.TotalSeconds - expected) / expected);

            Assert.LessOrEqual(variation, 0.2);
        }
    }
}
