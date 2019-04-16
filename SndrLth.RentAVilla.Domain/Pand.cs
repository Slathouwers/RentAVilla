using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.Domain
{
    public class Pand
    {
        private int _maxAantalPersonen;
        private int _minVerblijfsduur;
        private double _toeslagPersoonsOvernachting;
        private double _waarborg;
        private double _schoonmaak;

        public ActieveLanden Land { get; set; }
        public string Regio { get; set; }
        public string Plaats { get; set; }
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

        public double Waarborg
        {
            get
            {
                return _waarborg;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(_waarborg)}: " +
                        $"{value} is smaller than zero (negative price exception)");

                }
                _waarborg = value;
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

        public double ToeslagPersoonsOvernachting
        {
            get
            {
                return _toeslagPersoonsOvernachting;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(_toeslagPersoonsOvernachting)}: " +
                        $"{value} is smaller than zero (negative price exception)");

                }
                _toeslagPersoonsOvernachting = value;
            }
        }

        public double Schoonmaak
        {
            get
            {
                return _schoonmaak;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(_schoonmaak)}: " +
                        $"{value} is smaller than zero (negative price exception)");

                }
                _schoonmaak = value;
            }
        }
        //------------------------------------
        // TODO: PRICES SHOULD BE DECORATORS!!!!!!!!
        //------------------------------------
        public Dictionary<Tarief, double> TariefGebondenPrijsPerNacht { get; set; }
        public Dictionary<DateTime, Tarief> TariefStartData { get; set; }
    }
}
