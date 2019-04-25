using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen
{
    public class SchoonmaakPrijs : BasePrijsComponent
    {
        public SchoonmaakPrijs(double waarde)
        {
            Waarde = waarde;
        }

        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerReservatie;

        public static explicit operator SchoonmaakPrijs(double v)
        {
            return new SchoonmaakPrijs(v);
        }
    }

}
