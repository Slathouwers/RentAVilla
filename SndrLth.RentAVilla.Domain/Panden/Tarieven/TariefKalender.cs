using System;
using System.Collections.Generic;
using System.Linq;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain.Tarieven
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

            var t = Count != 0 ? this.Single(el => el.StartDatum == tariefKey) : new TariefKalenderRegistratie(datum, Tarief.Ongekend);

            return t.TariefType;
        }

        public void InsertWithOverride(Periode periode, Tarief tarief)
        {
            Tarief laatsteType;
            //Delete all overlapping KalenderRegistraties except last registration in periode => set startdate equal to periode.eindeq
            var overlaps = this.Where(registratie => periode.Overlapt(registratie.StartDatum));
            if (overlaps.Count() != 0)
            {
                laatsteType = this.Single(registratie => registratie.StartDatum == overlaps.Max(overlapReg => overlapReg.StartDatum)).TariefType;
                RemoveAll(registratie => periode.Overlapt(registratie.StartDatum));

            }
            else
            {
                var registratiesVoorStart = this.Where(registratie => registratie.StartDatum < periode.Start);
                laatsteType = this.Single(registratie => registratie.StartDatum == registratiesVoorStart.Max(reg => reg.StartDatum)).TariefType;
            }

            //Add period.Start and tarief as new registration
            Add(new TariefKalenderRegistratie(periode.Start, tarief));
            Add(new TariefKalenderRegistratie(periode.Eind, laatsteType));
        }

        public void InsertWhereBeschikbaar(Periode periode, Tarief tarief)
        {
            Tarief laatsteType;
            var overlaps = this.Where(registratie => periode.Overlapt(registratie.StartDatum));
            if (overlaps.Count() != 0)
            {
                laatsteType = this.Single(registratie => registratie.StartDatum == overlaps.Max(overlapReg => overlapReg.StartDatum)).TariefType;
                ForEach(registratie =>
                {
                    registratie.TariefType = registratie.TariefType != Tarief.Onbeschikbaar ? tarief : Tarief.Onbeschikbaar;
                });

            }
            else
            {
                var registratiesVoorEind = this.Where(registratie => registratie.StartDatum < periode.Eind);
                laatsteType = this.Single(registratie => registratie.StartDatum == registratiesVoorEind.Max(reg => reg.StartDatum)).TariefType;
            }

            //Add period.Start and tarief as new registration
            if (!Exists(registratie => registratie.StartDatum == periode.Start)) Add(new TariefKalenderRegistratie(periode.Start, tarief));
            Add(new TariefKalenderRegistratie(periode.Eind, laatsteType));
        }
    }
}
