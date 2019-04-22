using SndrLth.RentAVilla.Domain.PrijsKlassen;

namespace SndrLth.RentAVilla.Domain
{
    public class StaffelTranche
    {

        public StaffelTranche(int minimumAantalNachten, PercentuelePromotie trancheKorting)
        {
            MinimumAantalNachten = minimumAantalNachten;
            TrancheKorting = trancheKorting;
        }

        public int MinimumAantalNachten { get; set; }
        public PercentuelePromotie TrancheKorting { get; set; }
    }
}