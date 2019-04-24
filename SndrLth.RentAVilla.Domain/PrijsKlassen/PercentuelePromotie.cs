using SndrLth.RentAVilla.Domain.Enums;
using System;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PercentuelePromotie : BasePrijsComponent
    {
        private IPrijs _onderliggendePrijsComponent;
        private double _percent;
        public PercentuelePromotie(double percent)
        {
            GeldigheidsPeriode = new Periode("01/01/1900","31/12/2999");
            Percent = percent;
        }
        /// <summary>
        /// Maakt een 'virtuele' promotie zonder onderliggende prijscomponent. Waarde is dus gelijk aan 0!!
        /// </summary>
        /// <param name="geldigheidsPeriode"></param>
        /// <param name="toepassingsEenheid"></param>
        /// <param name="percent"></param>
        public PercentuelePromotie(Periode geldigheidsPeriode, double percent)
        {
            GeldigheidsPeriode = geldigheidsPeriode;
            Percent = percent;
        }
        /// <summary>
        /// Maakt een 'concrete' promotie met onderliggende prijscomponent waarop de promotie toegepast wordt
        /// </summary>
        /// <param name="geldigheidsPeriode"></param>
        /// <param name="toepassingsEenheid"></param>
        /// <param name="percent"></param>
        /// <param name="prijsComponent"></param>
        public PercentuelePromotie(Periode geldigheidsPeriode, double percent, IPrijs prijsComponent)
        {
            GeldigheidsPeriode = geldigheidsPeriode;
            Percent = percent;
            OnderliggendePrijsComponent = prijsComponent;
        }
        public Periode GeldigheidsPeriode { get; set; }
        public override PrijsEenheid ToepassingsEenheid { get =>(_onderliggendePrijsComponent == null)? PrijsEenheid.None: _onderliggendePrijsComponent.ToepassingsEenheid; }
        public override double Waarde { get => (_onderliggendePrijsComponent == null) ? 0 : _onderliggendePrijsComponent.Waarde * Percent; }
        public double Percent
        {
            get => _percent;
            set
            {
                if (value <= 0 && value>=-1) _percent = value;
                else throw new ArgumentOutOfRangeException("Positive discount should be negative value between -1 and 0");
            }
        }
        
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
                 Percent, prijsComponent);
        }
        public bool IsConcreet()
        {
            return _onderliggendePrijsComponent != null;
        }
    }

}

