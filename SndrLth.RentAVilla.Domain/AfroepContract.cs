namespace SndrLth.RentAVilla.Domain
{
    public class AfroepContract
    {


        public AfroepContract(Klant klant, Periode periode, int overnachtingsQuota)
        {
            Klant = klant;
            Periode = periode;
            OvernachtingsQuota = overnachtingsQuota;
        }

        public Klant Klant { get; private set; }
        public Periode Periode { get; private set; }
        public int OvernachtingsQuota { get; private set; }
    }
}