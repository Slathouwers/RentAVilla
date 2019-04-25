using System;
using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen;

namespace SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes
{
    public class PrijsOfferte : IPrijs, IPrijsOfferteOperations
    {
        private readonly List<PrijsOfferteRegel> _offerteRegels;
        private readonly TotaalPrijs _totaalPrijs;

        public PrijsOfferte()
        {
            _totaalPrijs = new TotaalPrijs(0);
            _offerteRegels = new List<PrijsOfferteRegel>();
        }

        public PrijsEenheid ToepassingsEenheid => _totaalPrijs.ToepassingsEenheid;
        public double Waarde => _totaalPrijs.Waarde;

        public void Add(IPrijs prijsComponent, int aantal)
        {
            if (_offerteRegels.Exists(el => el.PrijsComponent == prijsComponent))
                _offerteRegels.Find(el => el.PrijsComponent == prijsComponent).Eenheden += aantal;
            else _offerteRegels.Add(new PrijsOfferteRegel(prijsComponent, aantal));
            BerekenTotaalPrijs();
        }

        public void Add(IPrijs prijsComponent)
        {

            if (_offerteRegels.Exists(el => el.PrijsComponent == prijsComponent))
                _offerteRegels.Find(el => el.PrijsComponent == prijsComponent).Eenheden++;
            else _offerteRegels.Add(new PrijsOfferteRegel(prijsComponent));
            BerekenTotaalPrijs();
        }

        public void Remove(Type type)
        {
            _offerteRegels.RemoveAll(el => el.GetType() == type);
            BerekenTotaalPrijs();
        }

        public IEnumerable<string> PrintPrijsDetails()
        {
            foreach (var regel in _offerteRegels)
            {
                var regelhoofding = $"{nameof(regel.PrijsComponent)}";
                regelhoofding += regel.PrijsComponent is HuurPrijsPerNacht
                    ? $"{((HuurPrijsPerNacht) regel.PrijsComponent).TariefType.ToString()}"
                    : "";

                yield return
                    $"{regelhoofding}:    {regel.PrijsComponent.Waarde} {regel.PrijsComponent.ToepassingsEenheid.ToString()}    Aantal:{regel.Eenheden}    Subtotaal:{regel.Subtotaal}";
            }
        }

        public void BerekenTotaalPrijs()
        {
            double totaal = 0;
            foreach (var regel in _offerteRegels)
                if (regel.PrijsComponent.ToepassingsEenheid != PrijsEenheid.None)
                    totaal += regel.Subtotaal;
            _totaalPrijs.Waarde = totaal;
        }

        public void Add(IPrijs prijsComponent, int aantalNachten, int aantalPersonen)
        {
            if (_offerteRegels.Exists(el => el.PrijsComponent == prijsComponent)) Remove(prijsComponent.GetType());
            _offerteRegels.Add(new PrijsOfferteRegel(prijsComponent, aantalNachten, aantalPersonen));
        }
    }
}
