using SndrLth.RentAVilla.Domain.Prijzen.Promoties;

namespace SndrLth.RentAVilla.Domain.Klanten
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
