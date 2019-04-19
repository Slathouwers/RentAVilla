using System;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.TariefKlassen;

namespace SndrLth.RentAVilla.Domain
{
    //TODO: Refactor to new concrete Prijs components and and concrete Prijs Decorato
    public class Pand
    {

        private int _maxAantalPersonen;
        private int _minVerblijfsduur;

        public Pand()
        {
            TarievenPrijsLijst = new TarievenLijst();
        }

        public TarievenLijst TarievenPrijsLijst { get; }
        public TariefKalender TariefKalender { get; set; }
        public ActieveLanden Land { get; set; }
        public string Regio { get; set; }
        public string Plaats { get; set; }
        public Prijs SchoonmaakPrijs { get; } = new Prijs(0, PrijsEenheid.PerReservatie);
        public Prijs Waarborg { get; } = new Prijs(0, PrijsEenheid.PerReservatie);
        public Prijs PersoonstoeslagPerNacht { get; } = new Prijs(0, PrijsEenheid.PerPersoonPerNacht);
        public int MaxAantalPersonen
        {
            get => _maxAantalPersonen;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(MaxAantalPersonen)}: " +
                                                          $"{value} is smaller than or equal to zero (villa without rooms!)");
                _maxAantalPersonen = value;
            }
        }

        public int MinVerblijfsduur
        {
            get => _minVerblijfsduur;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(_minVerblijfsduur)}:" +
                                                          $" {value} is smaller than zero (negative periode exception)");
                _minVerblijfsduur = value;
            }
        }

        public void SetSchoonmaakPrijs(double value)
        {
            SchoonmaakPrijs.Waarde = value;
        }

        public void SetWaarborg(double value)
        {
            Waarborg.Waarde = value;
        }

        public void SetPersoonstoeslagPerNacht(double value)
        {
            PersoonstoeslagPerNacht.Waarde = value;
        }
    }

}
