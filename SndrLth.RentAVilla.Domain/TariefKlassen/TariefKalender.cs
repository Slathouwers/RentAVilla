using System;
using System.Collections.Generic;
using System.Linq;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TariefKalender : List<TariefKalenderRegistratie>
    {
        public Tarief GetTariefTypeVoorDatum(DateTime datum)
        {
            var minimum = TimeSpan.MaxValue;
            var tariefKey = DateTime.MinValue;
            foreach (var tariefDatum in this.Select(el => el.StartDatum))
            {
                if (tariefDatum > datum) continue;

                if (datum.Subtract(tariefDatum) <= minimum)
                {
                    minimum = datum.Subtract(tariefDatum);
                    tariefKey = tariefDatum;
                }
            }

            return this.Single(el => el.StartDatum == tariefKey).TariefType;
        }
    }
}
