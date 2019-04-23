using SndrLth.RentAVilla.Domain.PrijsKlassen;

namespace SndrLth.RentAVilla.Domain
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

        public Klant Klant { get; private set; }
        public Periode Periode { get; private set; }
        public int OvernachtingsQuota { get; private set; }
        public VastePrijsPromotie VastePrijsPromotie { get; private set; }
    }
}