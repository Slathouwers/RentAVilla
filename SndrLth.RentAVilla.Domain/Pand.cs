using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain
{
    public class Pand
    {
        public Dictionary<TariefType, Prijs> TariefGebondenPrijsPerNacht { get; private set; }
        public Pand()
        {
            TariefGebondenPrijsPerNacht = new Dictionary<TariefType, Prijs>();
            foreach (TariefType tar in Enum.GetValues(typeof(TariefType)))
            {
                TariefGebondenPrijsPerNacht.Add(tar, new Prijs(0.00,PrijsEenheid.PerNacht));
            }

        }
        private int _maxAantalPersonen;
        private int _minVerblijfsduur;

        public ActieveLanden Land { get; set; }
        public string Regio { get; set; }
        public string Plaats { get; set; }

        public Prijs Schoonmaak { get; private set; } = new Prijs(0, PrijsEenheid.PerReservatie);
        public void SetSchoonmaak(double value)
        {
            Schoonmaak.Waarde = value;
        }

        public Prijs Waarborg { get; private set; } = new Prijs(0, PrijsEenheid.PerReservatie);
        public void SetWaarborg(double value)
        {
            Waarborg.Waarde = value;
        }

        public Prijs PersoonstoeslagPerNacht { get; private set; } = new Prijs(0, PrijsEenheid.PerPersoonPerNacht);
        public void SetPersoonstoeslagPerNacht(double value)
        {
            PersoonstoeslagPerNacht.Waarde = value;
        }
        

        public int MaxAantalPersonen
        {
            get
            {
                return _maxAantalPersonen;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(MaxAantalPersonen)}: " +
                        $"{value} is smaller than or equal to zero (villa without rooms!)");

                }
                _maxAantalPersonen = value;
            }
        }
        public int MinVerblijfsduur
        {
            get
            {
                return _minVerblijfsduur;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(_minVerblijfsduur)}:" +
                        $" {value} is smaller than zero (negative periode exception)");

                }
                _minVerblijfsduur = value;
            }
        }

        public Dictionary<DateTime, TariefType> TariefKalender { get; set; } = new Dictionary<DateTime, TariefType>();
    }
}
