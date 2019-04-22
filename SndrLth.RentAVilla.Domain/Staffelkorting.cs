using System.Collections.Generic;

namespace SndrLth.RentAVilla.Domain
{
    public class Staffelkorting
    {
        public Staffelkorting(string naam)
        {
            Naam = naam;
            KlantCategorieLijst = new List<KlantCategorie>();
            StaffelTrancheLijst = new List<StaffelTranche>();
        }

        public string Naam { get; }
        public List<KlantCategorie> KlantCategorieLijst { get; set; }
        public List<StaffelTranche> StaffelTrancheLijst { get; set; }
    }
}