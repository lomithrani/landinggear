using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandingGearLib;
using NSubstitute;
using NUnit.Framework;

namespace LandingGearLibTests
{
    [TestFixture]
    public class ComputinModuleTests
    {
        [Test]
        public void ObserverReceiveThreeCallsWhenSuscribedAndThreeCylinderAdded()
        {
            GlobalValve generalValve = new GlobalValve();
            var module = new ComputingModule(generalValve);

            ElectroValve valve = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Retraction, true);
            ElectroValve valveOpen = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Extension, true);

            valve.Cylinders.Add(new FrontGear("Front",Cylinder.Targets.Gears));
            valve.Cylinders.Add(new SideGear("Left", Cylinder.Targets.Gears));
            valve.Cylinders.Add(new SideGear("Right", Cylinder.Targets.Gears));

            var observer = Substitute.For<ObserverTest>();
            module.Subscribe(observer);
        
            foreach (var cylinder in valve.Cylinders)
            {
                
                valveOpen.Cylinders.Add(cylinder);
                module.CylinderAdd(cylinder);
            }

            observer.Received(3).OnNext(Arg.Any<Cylinder>());
        }

        [Test]
        public void WhenPressureIsOkUpCommandLiftCylinders()
        {
            GlobalValve generalValve = new GlobalValve();
            var module = new ComputingModule(generalValve);

            ElectroValve valveGearClose = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Retraction, false);
            ElectroValve valveGearOpen = new ElectroValve(ElectroValve.Targets.Gears, ElectroValve.Types.Extension, false);
            ElectroValve valveDoorClose = new ElectroValve(ElectroValve.Targets.Doors, ElectroValve.Types.Retraction, false);
            ElectroValve valveDoorOpen = new ElectroValve(ElectroValve.Targets.Doors, ElectroValve.Types.Extension, false);

            module.GetValvesFromGeneral();

            generalValve.Valves.Add(valveDoorOpen);
            generalValve.Valves.Add(valveDoorClose);
            generalValve.Valves.Add(valveGearClose);
            generalValve.Valves.Add(valveGearOpen);

            var frontGear = new FrontGear("Front", Cylinder.Targets.Gears);
            var leftGear = new SideGear("Left", Cylinder.Targets.Gears);
            var rightGear = new SideGear("Right", Cylinder.Targets.Gears);

            valveGearClose.Cylinders.Add(frontGear);
            valveGearClose.Cylinders.Add(leftGear);
            valveGearClose.Cylinders.Add(rightGear);
            valveGearOpen.Cylinders.Add(frontGear);
            valveGearOpen.Cylinders.Add(leftGear);
            valveGearOpen.Cylinders.Add(rightGear);

            var frontDoor = new FrontDoor("Front", Cylinder.Targets.Doors);
            var leftDoor = new SideDoor("Left", Cylinder.Targets.Doors);
            var rightDoor = new SideDoor("Right", Cylinder.Targets.Doors);

            valveDoorClose.Cylinders.Add(frontDoor);
            valveDoorClose.Cylinders.Add(leftDoor);
            valveDoorClose.Cylinders.Add(rightDoor);
            valveDoorOpen.Cylinders.Add(frontDoor);
            valveDoorOpen.Cylinders.Add(leftDoor);
            valveDoorOpen.Cylinders.Add(rightDoor);

            valveDoorOpen.Cylinders.ForEach(c => module.CylinderAdd(c));
            valveGearOpen.Cylinders.ForEach(c => module.CylinderAdd(c));

            //make the plane fly
           valveGearOpen.Cylinders.ForEach(c => c.OnFloor = false); 

            module.Up();

            System.Threading.Thread.Sleep(10000);


        }
    }
}
