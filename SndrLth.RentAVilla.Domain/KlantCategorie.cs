using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain
{
    public class KlantCategorie
    {
        public KlantCategorie(KlantCategorieNaam naam)
        {
            Naam = naam;
        }
        public KlantCategorie(KlantCategorieNaam naam, Staffelkorting staffelkorting)
        {
            Naam = naam;
            Staffelkorting = staffelkorting;
        }

        public KlantCategorieNaam Naam { get; set; }
        public Staffelkorting Staffelkorting { get; set; }
    }
}
