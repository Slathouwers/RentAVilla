using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    // Abstract PrijsComponent decorator class
    public abstract class PrijsComponentDecorator : IPrijs
    {
        private double _waarde;
        public abstract PrijsEenheid ToepassingsEenheid { get; set; }
        public virtual double Waarde
        {
            get => _waarde;
            set
            {
                if (value >= 0) _waarde = value;
                else throw new ArgumentOutOfRangeException("Negative price");
            }
        }
    }

}

