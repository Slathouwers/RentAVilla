using System;

namespace SndrLth.RentAVilla.Domain.Enums
{
    [Flags]
    public enum PrijsEenheid : byte
    {
        None = 0,
        PerReservatie = 1 << 0,
        PerNacht = PerReservatie << 1,
        PerPersoon = PerNacht << 1,
        // Combinaties
        PerPersoonPerNacht = PerNacht | PerPersoon,
        PerReservatiePerPersoon = PerReservatie | PerPersoon,
        Subtotaal = PerNacht | PerPersoon | PerReservatie

    }
}
