using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class VastePrijsPromotie : PrijsComponentDecorator
    {/// <summary>
    /// Maakt een promotie voor een vast bedrag te korten per prijsEenheid
    /// </summary>
    /// <param name="periode"></param>
    /// <param name="toepassingsEenheid"></param>
    /// <param name="waarde"></param>
        public VastePrijsPromotie(Periode periode, PrijsEenheid toepassingsEenheid, double waarde)
        {
            Waarde = waarde;
            Periode = periode;
            ToepassingsEenheid = toepassingsEenheid;
        }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerReservatie;
        public Periode Periode { get; set; }
    }

}

