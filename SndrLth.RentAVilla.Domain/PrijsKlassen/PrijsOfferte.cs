using SndrLth.RentAVilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PrijsOfferte : IPrijs, IPrijsOfferteOperations
    {
        private List<PrijsOfferteRegel> offerteRegels;
        private readonly TotaalPrijs totaalPrijs;
        public PrijsOfferte() : base()
        {
            totaalPrijs = new TotaalPrijs(0);
        }
        public PrijsEenheid ToepassingsEenheid => totaalPrijs.ToepassingsEenheid;
        public double Waarde
        {
            get
            {
                return totaalPrijs.Waarde;
            }
        }
        public void BerekenTotaalPrijs()
        {
            double totaal = 0;
            foreach (PrijsOfferteRegel regel in offerteRegels)
            {
                if (regel.PrijsComponent.ToepassingsEenheid != PrijsEenheid.None)
                {
                    totaal += regel.Subtotaal;
                }
            }
            totaalPrijs.Waarde = totaal;
        }

        public void Add(IPrijs prijsComponent, int aantal)
        {
            if (offerteRegels.Exists(el => el.PrijsComponent == prijsComponent))
            {
                offerteRegels.Find(el => el.PrijsComponent == prijsComponent).Eenheden += aantal;
            }
            else offerteRegels.Add(new PrijsOfferteRegel(prijsComponent, aantal));
            BerekenTotaalPrijs();
        }

        public void Add(IPrijs prijsComponent)
        {

            if (offerteRegels.Exists(el => el.PrijsComponent == prijsComponent))
            {
                offerteRegels.Find(el => el.PrijsComponent == prijsComponent).Eenheden++;
            }
            else offerteRegels.Add(new PrijsOfferteRegel(prijsComponent));
            BerekenTotaalPrijs();
        }
        public void Remove(Type type)
        {
            offerteRegels.RemoveAll(el => el.GetType() == type);
            BerekenTotaalPrijs();
        }

        public IEnumerable<string> PrintPrijsDetails()
        {
            foreach (PrijsOfferteRegel regel in offerteRegels)
            {
                string regelhoofding = $"{nameof(regel.PrijsComponent)}";
                regelhoofding += (regel.PrijsComponent.GetType() == typeof(HuurPrijsPerNacht)) ? $"{((HuurPrijsPerNacht)regel.PrijsComponent).TariefType.ToString()}" : "";
                yield return $"{regelhoofding}:    {regel.PrijsComponent.Waarde} {regel.PrijsComponent.ToepassingsEenheid.ToString()}    Aantal:{regel.Eenheden}    Subtotaal:{regel.Subtotaal}";
            }
        }

    }
}
