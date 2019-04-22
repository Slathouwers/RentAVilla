using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    //Prijs interface
    public interface IPrijs
    {
        PrijsEenheid ToepassingsEenheid { get; set; }
        double Waarde { get; set; }
    }

}

