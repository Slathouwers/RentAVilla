using System;
using System.Collections.Generic;

namespace SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes
{
    internal interface IPrijsOfferteOperations
    {
        void Add(IPrijs prijsComponent, int aantal);
        void Add(IPrijs prijsComponent);
        IEnumerable<string> PrintPrijsDetails();
        void Remove(Type type);
    }
}
