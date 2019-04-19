using System;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TariefKalenderRegistratie
    {
        public TariefKalenderRegistratie(DateTime datum, TariefType type)
        {
            StartDatum = datum;
            TariefType = type;
        }

        public DateTime StartDatum { get; set; }
        public TariefType TariefType { get; set; }
    }
}
