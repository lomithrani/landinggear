using System;
using System.Collections.Generic;

namespace LandingGearLib
{
    internal class Unsubscriber<TCylinder> : IDisposable
    {
        private List<IObserver<TCylinder>> _observers;
        private IObserver<TCylinder> _observer;
        
        internal Unsubscriber(List<IObserver<TCylinder>> observers, IObserver<TCylinder> observer)
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
}