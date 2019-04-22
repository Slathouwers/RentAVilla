using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PersoonsToeslagPerNacht : PrijsComponentDecorator
    {
        public PersoonsToeslagPerNacht(double waarde)
        {
            Waarde = waarde;
        }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerPersoonPerNacht;

        public static explicit operator PersoonsToeslagPerNacht(double v)
        {
            return new PersoonsToeslagPerNacht(v);
        }

    }

}

