using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class AfroepContract
    {
        public AfroepContract(Klant klant, Pand pand, Periode periode, int overnachtingsQuota, VastePrijsPromotie vastePrijsPromotie)
        {
            Klant = klant;
            Pand = pand;
            Periode = periode;
            OvernachtingsQuota = overnachtingsQuota;
            VastePrijsPromotie = vastePrijsPromotie;
        }

        public Klant Klant { get; }
        public Pand Pand { get; }
        public Periode Periode { get; }
        public int OvernachtingsQuota { get; }
        public VastePrijsPromotie VastePrijsPromotie { get; }
    }
}
