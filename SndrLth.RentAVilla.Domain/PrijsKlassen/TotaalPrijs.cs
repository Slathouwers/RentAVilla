using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class TotaalPrijs : IPrijsComponent
    {
        public TotaalPrijs(double totaal)
        {
            Waarde = totaal;
        }

        public PrijsEenheid ToepassingsEenheid => PrijsEenheid.PerReservatie;

        public double Waarde { get; set; }
    }
}