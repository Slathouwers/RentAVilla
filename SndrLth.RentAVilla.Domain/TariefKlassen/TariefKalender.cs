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
            TariefKalenderRegistratie t = (this.Count!=0)? this.Single(el => el.StartDatum == tariefKey) : new TariefKalenderRegistratie(datum, Tarief.Ongekend); 
            return t.TariefType;
        }

        public void InsertWithOverride(Periode periode, Tarief tarief)
        {
            Tarief LaatsteType;
            //Delete all overlapping KalenderRegistraties except last registration in periode => set startdate equal to periode.eindeq
            IEnumerable<TariefKalenderRegistratie> overlaps = this.Where(registratie => periode.Overlapt(registratie.StartDatum));
            if(overlaps.Count() !=0)
            {
                LaatsteType = this.Single(registratie => registratie.StartDatum == overlaps.Max(overlapReg => overlapReg.StartDatum)).TariefType;
                foreach(TariefKalenderRegistratie overlapregistratie in overlaps){
                    Remove(overlapregistratie);
                }
               
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
    }
}
