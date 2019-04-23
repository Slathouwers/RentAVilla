using SndrLth.RentAVilla.Domain.Enums;
using System;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class VastePrijsPromotie : PrijsComponentDecorator

    {/// <summary>
     /// Maakt een promotie voor een vast bedrag te korten per prijsEenheid
     /// </summary>
     /// <param name="periode"></param>
     /// <param name="toepassingsEenheid"></param>
     /// <param name="waarde"></param>
        private double _waarde;
        public VastePrijsPromotie(double waarde)
        {
            Waarde = waarde;
            GeldigheidsPeriode = new Periode("01/01/1900", "31/12/2999");
        }
        public VastePrijsPromotie(Periode periode, double waarde)
        {
            Waarde = waarde;
            GeldigheidsPeriode = periode;
        }
        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerReservatie;
        public Periode GeldigheidsPeriode { get; set; }
        public override double Waarde
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

