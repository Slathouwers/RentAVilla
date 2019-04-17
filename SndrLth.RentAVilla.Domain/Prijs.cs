using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain
{
    public class Prijs
    {
        private double _waarde = 0.00;

        public double Waarde
        {
            get => _waarde;
            set
            {
                if (value >= 0) _waarde = value;
                else throw new ArgumentOutOfRangeException("Negative price");
            }
        }
        public PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.None;
        public Prijs(double value, PrijsEenheid toepassingsEenheid)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Negative price");
            Waarde = value;
            ToepassingsEenheid = toepassingsEenheid;
        }
    }
}
