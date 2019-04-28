using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class KlantenBestand : IEnumerable<Klant>
    {
        private IEnumerable<Klant> klanten;
        public KlantenBestand()
        {
            klanten = new Collection<Klant>();
        }

        public IEnumerator<Klant> GetEnumerator()
        {
            return klanten.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return klanten.GetEnumerator();
        }
    }
}
