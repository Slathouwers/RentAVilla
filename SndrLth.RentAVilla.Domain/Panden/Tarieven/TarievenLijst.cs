using System;
using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen;

namespace SndrLth.RentAVilla.Domain.Panden.Tarieven
{
    public class TarievenLijst : List<HuurPrijsPerNacht>
    {
        public TarievenLijst()
        {
            foreach (Tarief tar in Enum.GetValues(typeof(Tarief))) Add(new HuurPrijsPerNacht(tar, 0.00));

        }

        public HuurPrijsPerNacht this[Tarief t]
        {
            get => Find(el => el.TariefType == t);
            set
            {
                Find(el => el.TariefType == t).Waarde = value.Waarde;
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

        public void Update(Tarief t, double waarde)
        {
            Find(el => el.TariefType == t).Waarde = waarde;
        }
    }
}
