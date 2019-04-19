using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain
{
    //Prijs interface
    public interface IPrijs
    {
        PrijsEenheid ToepassingsEenheid { get; set; }
        double Waarde { get; set; }
    }
    // Abstract decorator class
    public abstract class PrijsComponent : IPrijs
    {
        private double _waarde;
        public abstract PrijsEenheid ToepassingsEenheid { get; set; }
        public double Waarde
        {
            get => _waarde;
            set
            {
                if (value >= 0) _waarde = value;
                else throw new ArgumentOutOfRangeException("Negative price");
            }
        }
    }
    //Concrete PrijsComponentDecorators
    public class Waarborg : PrijsComponent
    {
        public Waarborg(double waarde)
        {
            Waarde = waarde;
        }
        public static explicit operator Waarborg(double v)
        {
            return new Waarborg(v);
        }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerReservatie;
    }
    public class SchoonmaakPrijs : PrijsComponent
    {
        public SchoonmaakPrijs(double waarde)
        {
            Waarde = waarde;
        }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerReservatie;

        public static explicit operator SchoonmaakPrijs(double v)
        {
            return new SchoonmaakPrijs(v);
        }
    }

    public class PersoonsToeslagPerNacht : PrijsComponent
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
    public class DagPrijs : PrijsComponent
    {
        public DagPrijs(Tarief tarief, double waarde)
        {
            Waarde = waarde;
            TariefType = tarief;
        }
        public Tarief TariefType { get; set; }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerNacht;

        public static explicit operator DagPrijs(double v)
        {
            return new DagPrijs(Tarief.Ongekend, v);
        }
    }


    //public class Prijs : IPrijs
    //{
    //    private double _waarde;

    //    public Prijs(double value, PrijsEenheid toepassingsEenheid)
    //    {
    //        Waarde = value;
    //        ToepassingsEenheid = toepassingsEenheid;
    //    }

    //    public PrijsEenheid ToepassingsEenheid { get; set; }
    //    public double Waarde
    //    {
    //        get => _waarde;
    //        set
    //        {
    //            if (value >= 0) _waarde = value;
    //            else throw new ArgumentOutOfRangeException("Negative price");
    //        }
    //    }
    //}
}
