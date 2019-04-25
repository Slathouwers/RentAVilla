using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Prijzen.Promoties
{
    public abstract class BasePromotieComponent : IPrijs
    {
        private double _waarde;
        public abstract PrijsEenheid ToepassingsEenheid { get; }
        public virtual double Waarde
        {
            get => _waarde;
            set
            {
                if (value <= 0) _waarde = value;
                else throw new ArgumentOutOfRangeException("Positive discount should be negative");
            }
        }
    }
}
