using SndrLth.RentAVilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TariefKalender : List<TariefKalenderRegistratie>
    {

        public Tarief GetTariefTypeVoorDatum(DateTime datum)
        {
            TimeSpan minimum = TimeSpan.MaxValue;
            DateTime tariefKey = DateTime.MinValue;
            foreach (DateTime tariefDatum in this.Select(el => el.StartDatum))
            {
                if (tariefDatum > datum)
                {
                    continue;
                }

                if (datum.Subtract(tariefDatum) <= minimum)
                {
                    minimum = datum.Subtract(tariefDatum);
                    tariefKey = tariefDatum;
                }
            }
            TariefKalenderRegistratie t = (Count != 0) ? this.Single(el => el.StartDatum == tariefKey) : new TariefKalenderRegistratie(datum, Tarief.Ongekend);
            return t.TariefType;
        }

        public void InsertWithOverride(Periode periode, Tarief tarief)
        {
            Tarief LaatsteType;
            //Delete all overlapping KalenderRegistraties except last registration in periode => set startdate equal to periode.eindeq
            IEnumerable<TariefKalenderRegistratie> overlaps = this.Where(registratie => periode.Overlapt(registratie.StartDatum));
            if (overlaps.Count() != 0)
            {
                LaatsteType = this.Single(registratie => registratie.StartDatum == overlaps.Max(overlapReg => overlapReg.StartDatum)).TariefType;
                RemoveAll(registratie => periode.Overlapt(registratie.StartDatum));

            }
            else
            {
                IEnumerable<TariefKalenderRegistratie> RegistratiesVoorStart = this.Where(registratie => registratie.StartDatum < periode.Start);
                LaatsteType = this.Single(registratie => registratie.StartDatum == RegistratiesVoorStart.Max(Reg => Reg.StartDatum)).TariefType;
            }

            //Add period.Start and tarief as new registration
            Add(new TariefKalenderRegistratie(periode.Start, tarief));
            Add(new TariefKalenderRegistratie(periode.Eind, LaatsteType));
        }

        public void InsertWhereBeschikbaar(Periode periode, Tarief tarief)
        {
            Tarief LaatsteType;
            IEnumerable<TariefKalenderRegistratie> overlaps = this.Where(registratie => periode.Overlapt(registratie.StartDatum));
            if (overlaps.Count() != 0)
            {
                LaatsteType = this.Single(registratie => registratie.StartDatum == overlaps.Max(overlapReg => overlapReg.StartDatum)).TariefType;
                ForEach(registratie =>
                {
                    registratie.TariefType = (registratie.TariefType != Tarief.Onbeschikbaar) ? tarief : Tarief.Onbeschikbaar;
                });

            }
            else
            {
                IEnumerable<TariefKalenderRegistratie> RegistratiesVoorEind = this.Where(registratie => registratie.StartDatum < periode.Eind);
                LaatsteType = this.Single(registratie => registratie.StartDatum == RegistratiesVoorEind.Max(Reg => Reg.StartDatum)).TariefType;
            }

            //Add period.Start and tarief as new registration
            if(!this.Exists(registratie => registratie.StartDatum == periode.Start))
            {
                Add(new TariefKalenderRegistratie(periode.Start, tarief));
            }
            Add(new TariefKalenderRegistratie(periode.Eind, LaatsteType));
        }
    }
}
