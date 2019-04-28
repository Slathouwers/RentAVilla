using System;
using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Panden.Tarieven;
using SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain.Panden
{
    public class Pand
    {
        private int _maxAantalPersonen;
        private int _minVerblijfsduur;

        #region Constructors

        public Pand(string naam)
        {
            Naam = naam;
            _maxAantalPersonen = 0;
            _minVerblijfsduur = 0;
            TarievenLijst = new TarievenLijst();
            SchoonmaakPrijs = new SchoonmaakPrijs(0);
            TariefKalender = new TariefKalender();
            Waarborg = new Waarborg(0);
            PersoonsToeslagPerNacht = new PersoonsToeslagPerNacht(0.00);
        }

        #endregion

        public string Naam { get; }
        public TarievenLijst TarievenLijst { get; set; }
        public TariefKalender TariefKalender { get; set; }
        public ActieveLanden Land { get; set; }
        public string Regio { get; set; }
        public string Plaats { get; set; }
        public SchoonmaakPrijs SchoonmaakPrijs { get; set; }
        public Waarborg Waarborg { get; set; }
        public PersoonsToeslagPerNacht PersoonsToeslagPerNacht { get; set; }
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

        public IEnumerable<DateTime> GetOnbeschikbareNachten(Periode reservatiePeriode)
        {
            foreach (var d in reservatiePeriode.GetNachten())
                if (TariefKalender.GetTariefTypeVoorDatum(d) == Tarief.Onbeschikbaar)
                    yield return d;
        }
    }

}
