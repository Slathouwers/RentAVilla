using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.Domain.PrijsKlassen
{
    //Prijs interface
    public interface IPrijsComponent
    {
        PrijsEenheid ToepassingsEenheid { get; }
        double Waarde { get; set; }
    }

}

