using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain
{
    public class Pand
    {
        public ActieveLanden Land { get; set; }
        public string Regio { get; set; }
        public string Plaats { get; set; }
        public int MaxAantalPersonen { get; set; }
    }
}

namespace SndrLth.RentAVilla.Domain
{
    public enum ActieveLanden
    {
        Frankrijk,
        Italie,
        Portugal,
        Spanje
    }
}

namespace SndrLth.RentAVilla.Domain
{
    public enum TariefPeriodes
    {
        Onbeschikbaar,
        Hoogseizoen,
        Tussenseizoen,
        Laagseizoen
    }
}