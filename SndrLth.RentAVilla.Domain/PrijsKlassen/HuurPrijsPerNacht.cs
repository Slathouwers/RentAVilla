using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class HuurPrijsPerNacht : BasePrijsComponent
    {/// <summary>
    /// Maakt een tariefgebonden huurprijs per nacht
    /// </summary>
    /// <param name="tarief"></param>
    /// <param name="waarde"></param>
        public HuurPrijsPerNacht(Tarief tarief, double waarde)
        {
            Waarde = waarde;
            TariefType = tarief;
        }
        public Tarief TariefType { get; set; }
        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerNacht;

        public static explicit operator HuurPrijsPerNacht(double v)
        {
            return new HuurPrijsPerNacht(Tarief.Ongekend, v);
        }
    }

}

