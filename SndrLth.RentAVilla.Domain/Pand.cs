using System;
using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.TariefKlassen;

namespace SndrLth.RentAVilla.Domain
{
    public class Pand
    {

        private int _maxAantalPersonen;
        private int _minVerblijfsduur;

        public IEnumerable<DateTime> GetOnbeschikbareNachten(Periode reservatiePeriode)
        {
            foreach (DateTime d in reservatiePeriode.GetNachten())
            {
                if(TariefKalender.GetTariefTypeVoorDatum(d)==Tarief.Onbeschikbaar) yield return d;
            }
        }

        public Pand()
        {
            _maxAantalPersonen = 0;
            _minVerblijfsduur = 0;
            TarievenLijst = new TarievenLijst();
            SchoonmaakPrijs = new SchoonmaakPrijs(0);
            TariefKalender = new TariefKalender();
            Waarborg = new Waarborg(0);
            PersoonsToeslagPerNacht = (PersoonsToeslagPerNacht)0.00;
        }

        public TarievenLijst TarievenLijst { get; }
        public TariefKalender TariefKalender { get; set; }
        public ActieveLanden Land { get; set; }
        public string Regio { get; set; }
        public string Plaats { get; set; }
        public SchoonmaakPrijs SchoonmaakPrijs { get; }
        public Waarborg Waarborg { get; }
        public PersoonsToeslagPerNacht PersoonsToeslagPerNacht { get; }
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

        public void SetDagPrijs(double value)
        {
            PersoonsToeslagPerNacht.Waarde = value;
        }
    }

}
