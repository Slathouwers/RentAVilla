﻿using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes
{
    public class TotaalPrijs : IPrijs
    {
        public TotaalPrijs(double totaal)
        {
            Waarde = totaal;
        }

        public PrijsEenheid ToepassingsEenheid => PrijsEenheid.PerReservatie;
        public double Waarde { get; set; }
    }
}
