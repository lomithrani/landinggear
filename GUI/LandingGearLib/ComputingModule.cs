using System;
using System.Collections.Generic;

namespace LandingGearLib
{
    public class ComputingModule : IObservable<Cylinder> 
    {
        private List<IObserver<Cylinder>> observers;
        private List<Cylinder> valves;
        public IDisposable Subscribe(IObserver<Cylinder> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                // Provide observer with existing data.
                foreach (var item in valves)
                    observer.OnNext(item);
            }
            return new Unsubscriber<Cylinder>(observers, observer);
        }

        public void Down()
        {
            
        }
    }
}