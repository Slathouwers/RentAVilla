namespace SndrLth.RentAVilla.Domain
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