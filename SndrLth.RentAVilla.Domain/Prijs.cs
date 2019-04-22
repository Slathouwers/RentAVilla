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
    // Abstract PrijsComponent decorator class
    public abstract class PrijsComponent : IPrijs
    {
        private double _waarde;
        public abstract PrijsEenheid ToepassingsEenheid { get; set; }
        public virtual double Waarde
        {
            get => _waarde;
            set
            {
                if (value >= 0) _waarde = value;
                else throw new ArgumentOutOfRangeException("Negative price");
            }
        }
    }
    //Concrete PrijsComponenten
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
    public class HuurPrijsPerNacht : PrijsComponent
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
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerNacht;

        public static explicit operator HuurPrijsPerNacht(double v)
        {
            return new HuurPrijsPerNacht(Tarief.Ongekend, v);
        }
    }

    public class VastePrijsPromotie : PrijsComponent
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
    public class PercentuelePromotie : PrijsComponent
    {
        private IPrijs _onderliggendePrijsComponent;
        /// <summary>
        /// Maakt een 'virtuele' promotie zonder onderliggende prijscomponent. Waarde is dus gelijk aan 0!!
        /// </summary>
        /// <param name="geldigheidsPeriode"></param>
        /// <param name="toepassingsEenheid"></param>
        /// <param name="percent"></param>
        public PercentuelePromotie(Periode geldigheidsPeriode, PrijsEenheid toepassingsEenheid, double percent)
        {
            GeldigheidsPeriode = geldigheidsPeriode;
            ToepassingsEenheid = toepassingsEenheid;
            Percent = percent;
        }
        /// <summary>
        /// Maakt een 'concrete' promotie met onderliggende prijscomponent waarop de promotie toegepast wordt
        /// </summary>
        /// <param name="geldigheidsPeriode"></param>
        /// <param name="toepassingsEenheid"></param>
        /// <param name="percent"></param>
        /// <param name="prijsComponent"></param>
        public PercentuelePromotie(Periode geldigheidsPeriode, PrijsEenheid toepassingsEenheid, double percent, IPrijs prijsComponent)
        {
            GeldigheidsPeriode = geldigheidsPeriode;
            ToepassingsEenheid = toepassingsEenheid;
            Percent = percent;
            OnderliggendePrijsComponent = prijsComponent;
        }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerReservatie;
        public override double Waarde { get => (_onderliggendePrijsComponent == null)? 0 : _onderliggendePrijsComponent.Waarde * Percent; }
        public double Percent { get; set; }
        public Periode GeldigheidsPeriode { get; set; }
        public IPrijs OnderliggendePrijsComponent { get => _onderliggendePrijsComponent; set => _onderliggendePrijsComponent = value; }
        /// <summary>
        /// Maakt een nieuwe concrete promotie aan op basis 
        /// van de virtuele promotie en het meegegeven prijsComponent
        /// </summary>
        /// <param name="prijsComponent"></param>
        /// <returns></returns>
        public PercentuelePromotie GetConcretePromotieOp(IPrijs prijsComponent)
        {
            return new PercentuelePromotie(GeldigheidsPeriode,
                ToepassingsEenheid, Percent, prijsComponent);
        }
        public bool IsConcreet()
        {
            return _onderliggendePrijsComponent != null;
        }
    }

}

