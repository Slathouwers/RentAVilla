using System;
using System.Linq;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;

namespace SndrLth.RentAVilla.Domain
{
    public class Reservatie
    {
        private PrijsOfferteBuilder _prijsOfferteBuilder;

        public Reservatie(Pand pand, Klant klant, Periode reservatiePeriode, int aantalPersonen, PrijsOfferteBuilder prijsOfferteBuilder)
        {
            // pand beschikbaar voor reservatiePeriode?
            if (pand.GetOnbeschikbareNachten(reservatiePeriode).Any())
                throw new ArgumentException("Pand is onbeschikbaar voor periode" +
                                            $" {string.Join(", ", pand.GetOnbeschikbareNachten(reservatiePeriode))}");

            // reservatie voor geldig aantal personen?
            if (pand.MaxAantalPersonen < aantalPersonen)
                throw new ArgumentException($"Reservatie voor {aantalPersonen} " +
                                            $"personen overschrijdt maximum van {pand.MaxAantalPersonen} personen");

            // reservatie voor geldige verblijfsduur?
            if (pand.MinVerblijfsduur > reservatiePeriode.AantalNachten)
                throw new ArgumentException($"Reservatie voor {reservatiePeriode.AantalNachten} " +
                                            $"nachten voldoet niet aan minimum van {pand.MinVerblijfsduur} nachten");

            Pand = pand;
            Klant = klant;
            ReservatiePeriode = reservatiePeriode;
            AantalPersonen = aantalPersonen;
            _prijsOfferteBuilder = prijsOfferteBuilder;
        }

        public Pand Pand { get; }
        public Klant Klant { get; }
        public Periode ReservatiePeriode { get; }
        public int AantalPersonen { get; }
    }

}
