using System;
using System.Collections.Generic;

namespace SndrLth.RentAVilla.Domain
{
    public class Periode
    {
        private DateTime eind;
        private DateTime start;

        public Periode(DateTime start, DateTime eind)
        {
            Start = start;
            Eind = eind;
        }

        public Periode(string startDateString, string eindDateString)
        {
            if (!DateTime.TryParse(startDateString, out this.start) ||
                !DateTime.TryParse(eindDateString, out this.eind))
            {
                throw new ArgumentException($"Start('{startDateString}') or Eind('{eindDateString}') string do not have valid date formats!");
            }
        }

        public DateTime Eind
        {
            get => eind;
            set
            {
                if (start == null || value.Date.CompareTo(start.Date) <= 0)
                    throw new ArgumentException("Ongeldige Periode: eind is kleiner of gelijk aan start!");
                eind = value;
            }
        }
        public DateTime Start { get => start; set => start = value; }
        public int AantalNachten => Eind.Date.Subtract(Start.Date).Days;
        public bool Overlapt(Periode p)
        {
            return Start.Date < p.Eind.Date && Eind > p.Start.Date;
        }
        public bool Overlapt(DateTime d)
        {
            return Start.Date <= d && Eind > d;
        }

        public override string ToString()
        {
            return $"Start: {start.ToString("dd/MM/yyyy")}, Eind: {eind.ToString("dd/MM/yyyy")}.";
        }
        /// <summary>
        /// Returns Dates that include nights 
        /// ex. 21/04/2019 to 23/04/2019 returns 21/4 and 22/4 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DateTime> GetNachten()
        {
            for (DateTime d = Start; d < Eind; d = d.AddDays(1))
            {
                yield return d;
            }
        }
    }
}
