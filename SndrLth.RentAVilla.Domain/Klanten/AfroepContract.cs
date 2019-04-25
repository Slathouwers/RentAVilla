using SndrLth.RentAVilla.Domain.Prijzen.Promoties;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class AfroepContract
    {
        public AfroepContract(Klant klant, Periode periode, int overnachtingsQuota, VastePrijsPromotie vastePrijsPromotie)
        {
            Klant = klant;
            Periode = periode;
            OvernachtingsQuota = overnachtingsQuota;
            VastePrijsPromotie = vastePrijsPromotie;
        }

        public Klant Klant { get; }
        public Periode Periode { get; }
        public int OvernachtingsQuota { get; }
        public VastePrijsPromotie VastePrijsPromotie { get; }
    }
}
