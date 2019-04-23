using System;
using System.Linq;

namespace SndrLth.RentAVilla.Domain
{
    public class Reservatie
    {
        public Reservatie(Pand pand, Klant klant, Periode reservatiePeriode, int aantalPersonen)
        {
            // pand beschikbaar voor reservatiePeriode?
            if (pand.GetOnbeschikbareNachten(reservatiePeriode).Any())
            {
                throw new ArgumentException($"Pand is onbeschikbaar voor periode" +
                    $" {string.Join(", ", pand.GetOnbeschikbareNachten(reservatiePeriode))}");
            }
            // reservatie voor geldig aantal personen?
            if (pand.MaxAantalPersonen < aantalPersonen)
            {
                throw new ArgumentException($"Reservatie voor {aantalPersonen} " +
                    $"personen overschrijdt maximum van {pand.MaxAantalPersonen} personen");
            }
            // reservatie voor geldige verblijfsduur?
            if (pand.MinVerblijfsduur > reservatiePeriode.AantalNachten)
            {
                throw new ArgumentException($"Reservatie voor {reservatiePeriode.AantalNachten} " +
                   $"nachten voldoet niet aan minimum van {pand.MinVerblijfsduur} nachten");
            }

            Pand = pand;
            Klant = klant;
            ReservatiePeriode = reservatiePeriode;
        }

        public Pand Pand { get; private set; }
        public Klant Klant { get; private set; }
        public Periode ReservatiePeriode { get; private set; }
    }
}