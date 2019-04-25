using SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen;

namespace SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes
{
    public class PrijsOfferteRegel
    {
        public PrijsOfferteRegel(IPrijs prijsComponent)
        {
            PrijsComponent = prijsComponent;
            Eenheden = 1;
        }

        public PrijsOfferteRegel(IPrijs prijsComponent, int aantalNachten) : this(prijsComponent, aantalNachten, 0)
        {
        }

        public PrijsOfferteRegel(IPrijs prijsComponent, int aantalNachten, int aantalPersonen)
        {
            PrijsComponent = prijsComponent;
            Eenheden = aantalNachten;
            Personen = aantalPersonen;
        }

        public int Personen { get; set; }
        public IPrijs PrijsComponent { get; set; }
        public int Eenheden { get; set; }
        public double Subtotaal =>
            PrijsComponent.Waarde * Eenheden;
        public bool IsReturnable =>
            PrijsComponent.GetType() == typeof(Waarborg);
    }
}
