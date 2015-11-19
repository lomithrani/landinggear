using System;
using System.Collections.Generic;
using System.Linq;

namespace LandingGearLib
{
    public class ComputingModule : IObservable<Cylinder> 
    {
        private List<IObserver<Cylinder>> observers;
        private List<Cylinder> cylinders;
        private List<ElectroValve> valves;
        private GlobalValve _generalValve;

        public ComputingModule(GlobalValve valve)
        {
            _generalValve = valve;
            observers = new List<IObserver<Cylinder>>();
            cylinders = new List<Cylinder>();
        }

        public IDisposable Subscribe(IObserver<Cylinder> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                // Provide observer with existing data.
                foreach (var item in cylinders)
                    observer.OnNext(item);
            }
            return new Unsubscriber<Cylinder>(observers, observer);
        }

        internal class Unsubscriber<T> : IDisposable
        {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;

            internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void CylinderAdd(Cylinder cylinder)
        {
            cylinders.Add(cylinder);
            foreach (var observer in observers)
            {
                observer.OnNext(cylinder);
            }
        }

        public void GetValvesFromGeneral()
        {
            valves = _generalValve.Valves;
        }


        public void Up()
        {
            //stimulate general valve
            _generalValve.StartStimulate();


            // stimulate doors extension electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Extension).StartStimulate();

            //wait for all door cylinders to be opened and lock and the plane is not on floor
            while (!(
                cylinders.Where(c => c.Target == Cylinder.Targets.Doors).All(cyl => cyl.Gear_Extended && cyl.Is_Locked)
                &&
                cylinders.Where(c => c.Target == Cylinder.Targets.Gears).All(cyl => !cyl.OnFloor)
                ))
            {

            }

            //stimulate de geares retraction electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Gears && v.Type == ElectroValve.Types.Retraction).StartStimulate();

            //wait for all gear cylinders to be closed and lock
            while (!cylinders.Where(c => c.Target == Cylinder.Targets.Gears).All(cyl => cyl.Gear_retracted && cyl.Is_Locked))
            {

            }

            //stop stimulatiing doors extension electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Extension).EndStimulate();

            //stimulate doors retraction electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Retraction).StartStimulate();

            //wait for all door cylinders to be closed and lock
            while (!cylinders.Where(c => c.Target == Cylinder.Targets.Doors).All(cyl => cyl.Gear_retracted && cyl.Is_Locked))
            {

            }

            //end stimulation of closing doors
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Retraction).EndStimulate();

            //end stimulation of general valve
            _generalValve.EndStimulate();
        }

        public void Down()
        {
            //stimulate general valve
            _generalValve.StartStimulate();

            // stimulate doors extension electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Extension).StartStimulate();

            //wait for all door cylinders to be opend and lock
            while ( !cylinders.Where(c => c.Target == Cylinder.Targets.Doors).All(cyl => cyl.Gear_Extended && cyl.Is_Locked) )
            {

            }
            

            //stimulate de geares extension electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Gears && v.Type == ElectroValve.Types.Extension).StartStimulate();

            //wait for all gear cylinders to be opend and lock
            while (!cylinders.Where(c => c.Target == Cylinder.Targets.Gears).All(cyl => cyl.Gear_Extended && cyl.Is_Locked))
            {

            }
           
            //stop stimulatiing doors extension electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Extension).EndStimulate();

            //stimulate doors retraction electrovalve
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Retraction).StartStimulate();

            //wait for all door cylinders to be closed and lock
            while (!cylinders.Where(c => c.Target == Cylinder.Targets.Doors).All(cyl => cyl.Gear_retracted && cyl.Is_Locked))
            {

            }

            //end stimulation of closing doors
            valves.Single(v => v.Target == ElectroValve.Targets.Doors && v.Type == ElectroValve.Types.Retraction).EndStimulate();
            
            //end stimulation of general valve
            _generalValve.EndStimulate();

        }
    }
}