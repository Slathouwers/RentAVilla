﻿using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    public class SchoonmaakPrijs : PrijsComponentDecorator
    {
        public SchoonmaakPrijs(double waarde)
        {
            Waarde = waarde;
        }
        public override PrijsEenheid ToepassingsEenheid { get; set; } = PrijsEenheid.PerReservatie;

        public static explicit operator SchoonmaakPrijs(double v)
        {
            return new SchoonmaakPrijs(v);
        }
    }

}
