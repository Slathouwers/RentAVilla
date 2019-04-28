using System;
using System.Linq;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;

namespace SndrLth.RentAVilla.Domain.Reservaties
{
    public class ReservatieBuilder
    {
        private readonly PrijsOfferteBuilder _prijsOfferteBuilder;

        public ReservatieBuilder(PrijsOfferteBuilder offerteBuilder)
        {
            _prijsOfferteBuilder = offerteBuilder;
        }


        public Reservatie MaakReservatie(Pand pand, Klant klant, Periode reservatiePeriode, int aantalPersonen)
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
            PrijsOfferte prijsOfferte = _prijsOfferteBuilder.GetPrijsOfferte(pand, reservatiePeriode, klant, aantalPersonen);

            return new Reservatie(pand, klant, reservatiePeriode, aantalPersonen, prijsOfferte);
        }
    }
}
