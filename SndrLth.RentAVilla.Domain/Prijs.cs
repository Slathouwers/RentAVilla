using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain
{
    //Prijs component interface
    public interface IPrijs
    {
        PrijsEenheid ToepassingsEenheid { get; set; }
        double Waarde { get; set; }
    }
    //Concrete Prijs componenten
    public class Waarborg : IPrijs
    {
        public Waarborg(double waarde)
        {
            Waarde = waarde;
            ToepassingsEenheid = PrijsEenheid.PerReservatie;
        }
        public PrijsEenheid ToepassingsEenheid { get; set; }
        public double Waarde { get; set; }
    }
    public class SchoonmaakPrijs : IPrijs
    {
        public SchoonmaakPrijs(double waarde)
        {
            Waarde = waarde;
            ToepassingsEenheid = PrijsEenheid.PerReservatie;
        }
        public PrijsEenheid ToepassingsEenheid { get; set; }
        public double Waarde { get; set; }
    }

    public class PersoonsToeslagPerNacht : IPrijs
    {
        public PersoonsToeslagPerNacht(double waarde)
        {
            Waarde = waarde;
            ToepassingsEenheid = PrijsEenheid.PerPersoonPerNacht;
        }
        public PrijsEenheid ToepassingsEenheid { get; set; }
        public double Waarde { get; set; }
    }
    public class DagPrijs : IPrijs
    {
        public DagPrijs(Tarief tarief, double waarde)
        {
            Waarde = waarde;
            TariefType = tarief;
            ToepassingsEenheid = PrijsEenheid.PerNacht;
        }

        public DagPrijs(Tarief tarief, IPrijs prijs)
        {
            Waarde = prijs.Waarde;
            TariefType = tarief;
            ToepassingsEenheid = PrijsEenheid.PerNacht;
        }

        public Tarief TariefType { get; set; }
        public PrijsEenheid ToepassingsEenheid { get; set; }
        public double Waarde { get; set; }

        public static explicit operator DagPrijs(Prijs v)
        {
            return new DagPrijs(Tarief.Ongekend, v);
        }
    }

    // Abstract decorator class
    public abstract class PrijsDecorator : IPrijs
    {
        public abstract PrijsEenheid ToepassingsEenheid { get; set; }
        public abstract double Waarde { get; set; }
    }
    public class Prijs : IPrijs
    {
        private double _waarde;

        public Prijs(double value, PrijsEenheid toepassingsEenheid)
        {
            Waarde = value;
            ToepassingsEenheid = toepassingsEenheid;
        }

        public PrijsEenheid ToepassingsEenheid { get; set; }
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
}
