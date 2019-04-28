using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen
{
    //Concrete PrijsComponenten
    public sealed class Waarborg : BasePrijsComponent
    {
        public Waarborg(double waarde)
        {
            Waarde = waarde;
        }

        public override PrijsEenheid ToepassingsEenheid { get; } = PrijsEenheid.PerReservatie;

        public static explicit operator Waarborg(double v)
        {
            return new Waarborg(v);
        }
    }

}
