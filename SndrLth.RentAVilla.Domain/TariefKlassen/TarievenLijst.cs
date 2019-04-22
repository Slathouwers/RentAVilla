using System;
using System.Collections.Generic;
using System.Linq;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.TariefKlassen
{
    public class TarievenLijst : List<HuurPrijsPerNacht>
    {
        public TarievenLijst() 
        {
            foreach (Tarief tar in Enum.GetValues(typeof(Tarief)))
            {
                Add(new HuurPrijsPerNacht(tar, 0.00));
            }
                
        }

        public new void Add(HuurPrijsPerNacht item)
        {
            if (Exists(el => el.TariefType == item.TariefType))
                throw new ArgumentException($"Tarief '{item.TariefType.ToString()}' heeft al een prijs!");
            base.Add(item);
        }
        public void Update(HuurPrijsPerNacht item)
        {
            Find(el => el.TariefType == item.TariefType).Waarde = item.Waarde;
        }

        public HuurPrijsPerNacht this[Tarief t]
        {
            get => Find(el => el.TariefType == t);
            set
            {
                RemoveAll(el => el.TariefType == t);
                Add(new HuurPrijsPerNacht(t, value.Waarde));
            }
            
        } 
    }
}