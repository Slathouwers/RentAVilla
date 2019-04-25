using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Klanten
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
