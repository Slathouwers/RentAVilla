using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    //Concrete PrijsComponenten
    public class Waarborg : BasePrijsComponent
    {
        public Waarborg(double waarde)
        {
            Waarde = waarde;
        }
        public static explicit operator Waarborg(double v)
        {
            return new Waarborg(v);
        }
        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerReservatie;
    }

}

