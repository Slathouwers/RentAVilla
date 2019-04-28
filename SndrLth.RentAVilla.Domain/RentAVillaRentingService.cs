using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain
{
    public class RentAVillaRentingService
    {
        public HuurPandCatalogus HuurPanden { get; private set; }
        public PandBuilder PandBuilder { get; private set; }
        public ReservatieBoek ReservatieBoek { get; private set; }
        public ReservatieBuilder ReservatieBuilder { get; private set; }
        public PrijsOfferteBuilder PrijsOfferteBuilder { get; private set; }
        public Promoties Promoties{ get; private set; }
        public KlantenBestand KlantenBestand { get; private set; }
        public KlantBuilder KlantBuilder { get; private set; }
        public List<AfroepContract> AfroepContracten { get; private set; }
        public List<KlantCategorie> KlantCategorieën { get; private set; }

        public RentAVillaRentingService()
        {
            PandBuilder = new PandBuilder();
            HuurPanden = new HuurPandCatalogus();
            ReservatieBoek = new ReservatieBoek();
            KlantenBestand = new KlantenBestand();
            KlantCategorieën = new List<KlantCategorie>();
            AfroepContracten = new List<AfroepContract>();
            Promoties = new Promoties();
            PrijsOfferteBuilder = new PrijsOfferteBuilder(Promoties);
            ReservatieBuilder = new ReservatieBuilder(PrijsOfferteBuilder);
            KlantBuilder = new KlantBuilder(KlantCategorieën);
        }

    }
}
