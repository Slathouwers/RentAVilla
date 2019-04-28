using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class Klant
    {
        public Klant(KlantCategorie categorie, string naam)
        {
            Categorie = categorie;
            Naam = naam;
        }

        public KlantCategorie Categorie { get; set; }
        public string Naam { get; set; }
    }
}
