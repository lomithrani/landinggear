using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandingGearLib;

namespace LandingGearLibTests
{
    public  class ObserverTest : IObserver<Cylinder>
    {
        public virtual void OnNext(Cylinder value)
        {
          System.Diagnostics.Debug.WriteLine("test");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
