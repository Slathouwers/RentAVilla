using System;
using System.Linq;

namespace SndrLth.RentAVilla.Domain
{
    public class Reservatie
    {


        public Reservatie(Pand pand, Klant klant, Periode reservatiePeriode)
        {
            // pand beschikbaar voor reservatiePeriode?
            if(pand.GetOnbeschikbareNachten(reservatiePeriode).Any())
                throw new ArgumentException($"Pand is onbeschikbaar voor periode" +
                    $" {String.Join(", ",pand.GetOnbeschikbareNachten(reservatiePeriode))}");
            Pand = pand;
            Klant = klant;
            ReservatiePeriode = reservatiePeriode;
            //TODO: update pand TariefKalender
        }

        public Pand Pand { get; private set; }
        public Klant Klant { get; private set; }
        public Periode ReservatiePeriode { get; private set; }
    }
}