using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class PrijsOfferteRegel
    {
        public PrijsOfferteRegel(IPrijsComponent prijsComponent, int hoeveelheid)
        {
            PrijsComponent = prijsComponent;
            Eenheden = hoeveelheid;
        }
        public PrijsOfferteRegel(IPrijsComponent prijsComponent)
        {
            PrijsComponent = prijsComponent;
            Eenheden = 1;
        }
        public IPrijsComponent PrijsComponent { get; set; }
        public int Eenheden { get; set; }
        public double Subtotaal
        {
            get => PrijsComponent.Waarde * Eenheden;
        }
        public bool isReturnable { get => PrijsComponent.GetType() == typeof(Waarborg); }
    }
}
