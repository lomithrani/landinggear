using System;
using System.Timers;

namespace LandingGearLib
{
    public abstract class Cylinder
    {

        public enum Targets
        {
            Doors,
            Gears
        }
        internal double _position;

        internal Cylinder(string location, Targets target)
        {
            Target = target;
            Is_Locked = true;
            Location = location;
            OnFloor = true;
            Timer = new Timer {Interval = 100}; //activate every 0.1 sec
            Timer.Start();
            incrementer = 0;
            _retract = false;
            _extend = false;
        }

        public string Location { get; internal set; }

        public Targets Target { get; internal set; }

        public Timer Timer { get; internal set; }

        public bool Is_Locked { get; internal set; }

        internal int incrementer { get; set; }

        public bool OnFloor { get; set; }

        public bool Gear_retracted => _position >= 90.0;

        public bool Gear_Extended => _position <= 0.0;

        internal int uidp;
        internal int fdthp;
        internal int lihp;
        internal int uihp;
        internal int fhtdp;
        internal int lidp;

        private bool _retract;
        private bool _extend;

        public void Retract()
        {
            incrementer = 0;
            if (!_retract)
            {
                Timer.Elapsed += Retract;
                _retract = true;
            }
            
           
        }

        public void StopRetract()
        {
            incrementer = 0;
            if (_retract)
            {
                Timer.Elapsed -= Retract;
                _retract = false;
            }
        }

        public void Extend()
        {
            incrementer = 0;
            if (!_extend)
            {
                Timer.Elapsed += Extend;
                _extend = true;
            }
      
        }

        public void StopExtend()
        {
            incrementer = 0;
            if (_extend)
            {
                Timer.Elapsed -= Extend;
                _extend = false;
            }
            
        }

        internal void Retract(object source, ElapsedEventArgs e)
        {
             
            if (Gear_Extended && Is_Locked)
            {
                incrementer++;
                if (incrementer >= uidp)
                {
                    Is_Locked = false;
                    incrementer = 0;
                }

            }
            if (!Gear_retracted && !Is_Locked)
            {
                _position += 90.0 / fdthp;
                if (_position >= 90.0)
                {
                    _position = 90.0;
                }
            }
            if (Gear_retracted && !Is_Locked)
            {
                incrementer++;
                if (incrementer >= lihp)
                {
                    Is_Locked = true;
                    incrementer = 0;
                }
            }
        }

        internal void Extend(object source, ElapsedEventArgs e)
        {
            if (Gear_retracted && Is_Locked)
            {
                incrementer++;
                if (incrementer >= uihp)
                {
                    Is_Locked = false;
                    incrementer = 0;
                }
            }
            if (!Gear_Extended && !Is_Locked)
            {
                _position -= 90.0 / fhtdp;
                if (_position <= 0.0)
                {
                    _position = 0.0;
                }
            }
            if (Gear_Extended && !Is_Locked)
            {
                incrementer++;
                if (incrementer >= lidp)
                {
                    Is_Locked = true;
                    incrementer = 0;
                }
            }
        }
    }
}