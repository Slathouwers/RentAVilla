using SndrLth.RentAVilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    class PrijsOfferte : List<PrijsOfferteRegel>
    {
        public PrijsOfferte() : base()
        {
        }
        public double Totaal
        {
            get
            {
                double totaal = 0;
                foreach (PrijsOfferteRegel regel in this)
                {
                    if (regel.PrijsComponent.ToepassingsEenheid.HasFlag(PrijsEenheid.Subtotaal))
                    {
                        totaal += regel.Subtotaal;
                    }
                }
                return totaal;
            }
        }
        public void Add(IPrijsComponent prijsComponent, int aantal)
        {
            if (Exists(el => el.PrijsComponent == prijsComponent))
            {
                Find(el => el.PrijsComponent == prijsComponent).Eenheden += aantal;
            }
            else Add(new PrijsOfferteRegel(prijsComponent, aantal));
        }
        public void Add(IPrijsComponent prijsComponent)
        {

            if (Exists(el => el.PrijsComponent == prijsComponent))
            {
                Find(el => el.PrijsComponent == prijsComponent).Eenheden++;
            }
            else Add(new PrijsOfferteRegel(prijsComponent));
        }
       

    }
}
