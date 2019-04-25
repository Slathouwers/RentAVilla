using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen
{
    public sealed class PersoonsToeslagPerNacht : BasePrijsComponent
    {
        public PersoonsToeslagPerNacht(double waarde)
        {
            Waarde = waarde;
        }

        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerPersoonPerNacht;

        public static explicit operator PersoonsToeslagPerNacht(double v)
        {
            return new PersoonsToeslagPerNacht(v);
        }
    }

}
