using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PercentuelePromotie : PrijsComponentDecorator
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

