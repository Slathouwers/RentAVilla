using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain.Panden
{
    public class PandBuilder
    {
        private Pand _pand;

        public PandBuilder CreatePand(string naam)
        {
            _pand = new Pand(naam);

            return this;
        }

        public PandBuilder MetLocation(ActieveLanden land, string regio, string plaats)
        {
            _pand.Land = land;
            _pand.Regio = regio;
            _pand.Plaats = plaats;

            return this;
        }

        public PandBuilder MetTarief(Tarief t, double waarde)
        {
            return MetTarief(t, waarde, null);
        }

        public PandBuilder MetTarief(Tarief t, double waarde, Periode periode)
        {
            if (periode != null) _pand.TariefKalender.InsertWithOverride(periode, t);
            _pand.TarievenLijst.Update(t, waarde);

            return this;
        }

        public PandBuilder MetTariefPeriode(Tarief t, Periode periode)
        {
            _pand.TariefKalender.InsertWithOverride(periode, t);

            return this;
        }

        public PandBuilder MetPrijzen(SchoonmaakPrijs schoonmaakPrijs,
            Waarborg waarborg,
            PersoonsToeslagPerNacht persoonsToeslagPerNacht)
        {
            _pand.SchoonmaakPrijs = schoonmaakPrijs;
            _pand.Waarborg = waarborg;
            _pand.PersoonsToeslagPerNacht = persoonsToeslagPerNacht;

            return this;
        }

        public PandBuilder MetLimieten(int maxAantalPersonen,
            int minVerblijfsduur)
        {
            _pand.MaxAantalPersonen = maxAantalPersonen;
            _pand.MinVerblijfsduur = minVerblijfsduur;

            return this;
        }

        public Pand Get()
        {
            return _pand;
        }
    }
}
