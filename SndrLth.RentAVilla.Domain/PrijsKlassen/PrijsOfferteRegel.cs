using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PrijsOfferteRegel
    {
        public PrijsOfferteRegel(IPrijs prijsComponent, int hoeveelheid)
        {
            PrijsComponent = prijsComponent;
            Eenheden = hoeveelheid;
        }
        public PrijsOfferteRegel(IPrijs prijsComponent)
        {
            PrijsComponent = prijsComponent;
            Eenheden = 1;
        }
        public IPrijs PrijsComponent { get; set; }
        public int Eenheden { get; set; }
        public double Subtotaal
        {
            get => PrijsComponent.Waarde * Eenheden;
        }
        public bool isReturnable { get => PrijsComponent.GetType() == typeof(Waarborg); }
    }
}
