using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class KlantBuilder
    {
        private List<KlantCategorie> _klantCategorieën;

        public KlantBuilder(List<KlantCategorie> klantCategorieën)
        {
            _klantCategorieën = klantCategorieën;
        }

        public Klant MaakKlant(string klantNaam, KlantCategorieNaam klantCategorieNaam)
        {
            if(!_klantCategorieën.Exists(cat => cat.Naam == klantCategorieNaam)) _klantCategorieën.Add(new KlantCategorie(klantCategorieNaam));
            return new Klant(_klantCategorieën.First<KlantCategorie>(cat => cat.Naam == klantCategorieNaam),klantNaam);
        }

    }
}
