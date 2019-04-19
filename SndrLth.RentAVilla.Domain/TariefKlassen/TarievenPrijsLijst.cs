using System;
using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TarievenPrijsLijst : List<TariefPrijs>
    {
        public TarievenPrijsLijst() 
        {
            foreach (TariefType tar in Enum.GetValues(typeof(TariefType)))
            {
                Add(new TariefPrijs(tar, new Prijs(0.00, PrijsEenheid.PerNacht)));
            }
                
        }

        public new void Add(TariefPrijs item)
        {
            if (Exists(el => el.TariefType == item.TariefType))
                throw new ArgumentException($"Tarief '{item.TariefType.ToString()}' heeft al een prijs!");
            base.Add(item);
        }

        public Prijs this[TariefType t]
        {
            get => Find(el => el.TariefType == t).Prijs;
            set
            {
                RemoveAll(el => el.TariefType == t);
                Add(new TariefPrijs(t, value));
            }
            
        } 
    }
}