using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SndrLth.RentAVilla.Domain.Reservaties
{
    public class ReservatieBoek 
    {
        private IEnumerable<Reservatie> _reservaties;
        public ReservatieBoek()
        {
            _reservaties = new Collection<Reservatie>();
        }

        public IEnumerable<Reservatie> GetAll()
        {
            return _reservaties.AsEnumerable();
        }
        //Add
        public void Add(Reservatie reservatie)
        {
            if(_reservaties.Any(res => res.Pand == reservatie.Pand && res.ReservatiePeriode.Overlapt(reservatie.ReservatiePeriode))) throw new ArgumentException("Pand reeds gereserveerd in deze periode");
            _reservaties.Append(reservatie);
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
    }
}
