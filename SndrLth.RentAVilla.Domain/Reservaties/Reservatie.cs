using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;

namespace SndrLth.RentAVilla.Domain.Reservaties
{
    public class Reservatie
    {
        public Reservatie(Pand pand, Klant klant, Periode reservatiePeriode, int aantalPersonen, PrijsOfferte prijsOfferte)
        {
            Pand = pand;
            Klant = klant;
            ReservatiePeriode = reservatiePeriode;
            AantalPersonen = aantalPersonen;
            PrijsOfferte = prijsOfferte;
        }

        public Pand Pand { get; }
        public Klant Klant { get; }
        public Periode ReservatiePeriode { get; }
        public int AantalPersonen { get; }
        public PrijsOfferte PrijsOfferte { get; }
    }

}
