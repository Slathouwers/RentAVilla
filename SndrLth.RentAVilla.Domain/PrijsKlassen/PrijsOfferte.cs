using SndrLth.RentAVilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PrijsOfferte : List<PrijsOfferteRegel>, IPrijsComponent
    {
        private TotaalPrijs _totaalPrijs;
        public PrijsOfferte() : base()
        {
            _totaalPrijs = new TotaalPrijs(0);
        }
        public PrijsEenheid ToepassingsEenheid => ((IPrijsComponent)_totaalPrijs).ToepassingsEenheid;
        public double Waarde
        {
            get
            {

                return ((IPrijsComponent)_totaalPrijs).Waarde;
            }
        }
        public void BerekenTotaalPrijs()
        {
            double totaal = 0;
            foreach (PrijsOfferteRegel regel in this)
            {
                if (regel.PrijsComponent.ToepassingsEenheid != PrijsEenheid.None)
                {
                    totaal += regel.Subtotaal;
                }
            }
            _totaalPrijs.Waarde = totaal;
        }

        public void Add(IPrijsComponent prijsComponent, int aantal)
        {
            if (Exists(el => el.PrijsComponent == prijsComponent))
            {
                Find(el => el.PrijsComponent == prijsComponent).Eenheden += aantal;
            }
            else Add(new PrijsOfferteRegel(prijsComponent, aantal));
            BerekenTotaalPrijs();
        }

        public void Add(IPrijsComponent prijsComponent)
        {

            if (Exists(el => el.PrijsComponent == prijsComponent))
            {
                Find(el => el.PrijsComponent == prijsComponent).Eenheden++;
            }
            else Add(new PrijsOfferteRegel(prijsComponent));
            BerekenTotaalPrijs();
        }
        public void Remove(Type type)
        {
            RemoveAll(el => el.GetType() == type);
            BerekenTotaalPrijs();
        }

        public IEnumerable<string> PrintPrijsDetails()
        {
            foreach (PrijsOfferteRegel regel in this)
            {
                string regelhoofding = $"{nameof(regel.PrijsComponent)}";
                regelhoofding += (regel.PrijsComponent.GetType() == typeof(HuurPrijsPerNacht)) ? $"{((HuurPrijsPerNacht)regel.PrijsComponent).TariefType.ToString()}" : "";
                yield return $"{regelhoofding}:    {regel.PrijsComponent.Waarde} {regel.PrijsComponent.ToepassingsEenheid.ToString()}    Aantal:{regel.Eenheden}    Subtotaal:{regel.Subtotaal}";
            }
        }

    }
}
