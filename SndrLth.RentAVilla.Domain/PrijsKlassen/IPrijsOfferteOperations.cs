using System.Collections.Generic;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    internal interface IPrijsOfferteOperations
    {
        void Add(IPrijs prijsComponent, int aantal);
        void Add(IPrijs prijsComponent);
        IEnumerable<string> PrintPrijsDetails();
        void Remove(System.Type type);
    }
}