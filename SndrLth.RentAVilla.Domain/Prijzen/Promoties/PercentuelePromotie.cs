using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Prijzen.Promoties
{
    public class PercentuelePromotie : BasePromotieComponent
    {
        private double _percent;

        public PercentuelePromotie(double percent)
        {
            GeldigheidsPeriode = new Periode("01/01/1900", "31/12/2999");
            Percent = percent;
        }

        public PercentuelePromotie(Periode geldigheidsPeriode, double percent)
        {
            GeldigheidsPeriode = geldigheidsPeriode;
            Percent = percent;
        }

        public PercentuelePromotie(Periode geldigheidsPeriode, double percent, IPrijs prijsComponent)
        {
            GeldigheidsPeriode = geldigheidsPeriode;
            Percent = percent;
            OnderliggendePrijsComponent = prijsComponent;
        }

        public Periode GeldigheidsPeriode { get; set; }
        public override PrijsEenheid ToepassingsEenheid =>
            OnderliggendePrijsComponent == null ? PrijsEenheid.None : OnderliggendePrijsComponent.ToepassingsEenheid;
        public override double Waarde =>
            OnderliggendePrijsComponent == null ? 0 : OnderliggendePrijsComponent.Waarde * Percent;
        public double Percent
        {
            get => _percent;
            set
            {
                if (value <= 0 && value >= -1) _percent = value;
                else throw new ArgumentOutOfRangeException("Positive discount should be negative value between -1 and 0");
            }
        }

        public IPrijs OnderliggendePrijsComponent { get; set; }

        public PercentuelePromotie GetConcretePromotieOp(IPrijs prijsComponent)
        {
            return new PercentuelePromotie(GeldigheidsPeriode,
                Percent, prijsComponent);
        }

        public bool IsConcreet()
        {
            return OnderliggendePrijsComponent != null;
        }
    }

}
