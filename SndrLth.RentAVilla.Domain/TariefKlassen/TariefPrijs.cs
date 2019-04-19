using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TariefPrijs
    {
        public TariefPrijs(TariefType tarief, Prijs prijs)
        {
            TariefType = tarief;
            Prijs = prijs;
        }

        public TariefType TariefType { get; set; }
        public Prijs Prijs { get; set; }    
    }
}