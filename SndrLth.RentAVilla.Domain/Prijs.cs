using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain
{
    public class Prijs
    {
        private double _waarde;

        public Prijs(double value, PrijsEenheid toepassingsEenheid)
        {
            Waarde = value;
            ToepassingsEenheid = toepassingsEenheid;
        }

        public PrijsEenheid ToepassingsEenheid { get; set; }
        public double Waarde
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
