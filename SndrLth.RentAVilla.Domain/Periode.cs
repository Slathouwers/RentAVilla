using System;

namespace SndrLth.RentAVilla.Domain
{
    public class Periode
    {
        public Periode(DateTime start, DateTime eind)
        {
            if (eind.Date.CompareTo(start.Date) <= 0)
                throw new ArgumentException("Ongeldige Periode: eind is kleiner of gelijk aan start!");
            this.Start = start;
            this.Eind = eind;
        }

        public DateTime Eind { get; set; }
        public DateTime Start { get; set; }
        public int AantalNachten
        {
            get
            {
                return Eind.Date.Subtract(Start.Date).Days;
            }
        }
        public bool Overlapt(Periode p)
        {
            return this.Start.Date < p.Eind.Date && this.Eind > p.Start.Date;
        }
    }
}