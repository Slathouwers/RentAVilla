using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain
{
    public class Prijs
    {
        public double Waarde { get; set; } = 0.00;
        public PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.None;
        public Prijs(double value, PrijsEenheid toepassingsEenheid)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Negative price");
            Waarde = value;
            ToepassingsEenheid = toepassingsEenheid;
        }
    }
}
