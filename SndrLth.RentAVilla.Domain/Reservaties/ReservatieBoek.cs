using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SndrLth.RentAVilla.Domain.Panden;

namespace SndrLth.RentAVilla.Domain.Reservaties
{
    public class ReservatieBoek 
    {
        private IEnumerable<Reservatie> _reservaties;
        public ReservatieBoek()
        {
            _reservaties = new Collection<Reservatie>();
        }

        public List<Reservatie> GetAll()
        {
            return _reservaties.ToList();
        }
        //Add
        public void Add(Reservatie reservatie)
        {
            if(_reservaties.Any(res => res.Pand == reservatie.Pand && res.ReservatiePeriode.Overlapt(reservatie.ReservatiePeriode))) throw new ArgumentException("Pand reeds gereserveerd in deze periode");
           _reservaties = _reservaties.Append(reservatie);
        }
        //Remove
        public void Remove(Reservatie reservatie)
        {
            _reservaties = _reservaties.Where(res=> !res.Equals(reservatie));
        }
        //GetConflicterendeData
        public IEnumerable<DateTime> GetConflicterendeData(Reservatie reservatie)
        {
            foreach (DateTime nacht in reservatie.ReservatiePeriode.GetNachten())
            {
                if (_reservaties.Any(res => res.Pand == reservatie.Pand && res.ReservatiePeriode.Overlapt(nacht))) yield return nacht;
            }
        }

        public bool PandIsVrijVoorPeriode(Pand pand, Periode periode)
        {
            return !_reservaties.Any(res => res.Pand == pand && res.ReservatiePeriode.Overlapt(periode));
        }
    }
}
