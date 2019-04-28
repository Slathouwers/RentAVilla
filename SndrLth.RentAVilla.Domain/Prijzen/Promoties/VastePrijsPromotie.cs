using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain.Prijzen.Promoties
{
    public sealed class VastePrijsPromotie : BasePromotieComponent

    {
        public VastePrijsPromotie(double waarde)
        {
            Waarde = waarde;
            GeldigheidsPeriode = new Periode("01/01/1900", "31/12/2999");
        }

        /// <summary>
        ///     Maakt een promotie voor een vast bedrag te korten per prijsEenheid
        /// </summary>
        /// <param name="periode"></param>
        /// <param name="waarde"></param>
        public VastePrijsPromotie(Periode periode, double waarde)
        {
            Waarde = waarde;
            GeldigheidsPeriode = periode;
        }

        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerReservatie;
        public Periode GeldigheidsPeriode { get; set; }
    }

}
