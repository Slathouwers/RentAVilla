using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain
{
    public class RentAVillaRentingService
    {

        public RentAVillaRentingService()
        {
            PandBuilder = new PandBuilder(); //tested
            HuurPanden = new HuurPandCatalogus(); //tested
            ReservatieBoek = new ReservatieBoek();
            Promoties = new Promoties(); //tested
            PrijsOfferteBuilder = new PrijsOfferteBuilder(Promoties);
            ReservatieBuilder = new ReservatieBuilder(PrijsOfferteBuilder);
            KlantenBestand = new KlantenBestand(); //tested
            KlantCategorieën = new List<KlantCategorie>(); //tested
            AfroepContracten = new List<AfroepContract>(); //tested
            KlantBuilder = new KlantBuilder(KlantCategorieën); //tested

        }

        public HuurPandCatalogus HuurPanden { get; }
        public PandBuilder PandBuilder { get; }
        public ReservatieBoek ReservatieBoek { get; }
        public ReservatieBuilder ReservatieBuilder { get; }
        public PrijsOfferteBuilder PrijsOfferteBuilder { get; }
        public Promoties Promoties { get; }
        public KlantenBestand KlantenBestand { get; }
        public KlantBuilder KlantBuilder { get; }
        public List<AfroepContract> AfroepContracten { get; }
        public List<KlantCategorie> KlantCategorieën { get; }
    }
}
