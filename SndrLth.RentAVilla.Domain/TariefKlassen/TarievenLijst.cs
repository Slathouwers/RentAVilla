using System;
using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TarievenLijst : List<DagPrijs>
    {
        public TarievenLijst() 
        {
            foreach (Tarief tar in Enum.GetValues(typeof(Tarief)))
            {
                Add(new DagPrijs(tar, 0.00));
            }
                
        }

        public new void Add(DagPrijs item)
        {
            if (Exists(el => el.TariefType == item.TariefType))
                throw new ArgumentException($"Tarief '{item.TariefType.ToString()}' heeft al een prijs!");
            base.Add(item);
        }

        public DagPrijs this[Tarief t]
        {
            get => Find(el => el.TariefType == t);
            set
            {
                RemoveAll(el => el.TariefType == t);
                Add(new DagPrijs(t, value.Waarde));
            }
            
        } 
    }
}