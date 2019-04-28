using System.Linq;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes
{
    public class PrijsOfferteBuilder
    {
        private readonly PrijsOfferte _prijsOfferte;
        private readonly Promoties.Promoties _promoties;
        private int _aantalPersonen;
        private Klant _klant;
        private Pand _pand;
        private Periode _reservatiePeriode;

        public PrijsOfferteBuilder(Promoties.Promoties promoties)
        {
            _promoties = promoties;

            _prijsOfferte = new PrijsOfferte();
        }

        public PrijsOfferte GetPrijsOfferte(Pand pand, Periode reservatiePeriode, Klant klant, int aantalPersonen)
        {
            _pand = pand;
            _reservatiePeriode = reservatiePeriode;
            _klant = klant;
            _aantalPersonen = aantalPersonen;
            AddHuurpijsEnStaffelRegels();
            AddPandRegels();
            AddPromotieRegels();

            return _prijsOfferte;
        }

        private void AddPromotieRegels()
        {
            foreach (var promotie in _promoties) _prijsOfferte.Add(promotie);
        }

        private void AddPandRegels()
        {
            _prijsOfferte.Add(_pand.PersoonsToeslagPerNacht, _reservatiePeriode.AantalNachten, _aantalPersonen);
            _prijsOfferte.Add(_pand.SchoonmaakPrijs);
            _prijsOfferte.Add(_pand.Waarborg);

        }

        private void AddHuurpijsEnStaffelRegels()
        {
            var staffelkorting =
                _klant.Categorie.Staffelkorting.StaffelTrancheLijst
                    .Where(
                        el => el.MinimumAantalNachten <= _reservatiePeriode.AantalNachten)
                    .Max().TrancheKorting;
            foreach (var nacht in _reservatiePeriode.GetNachten())
            {
                var t = _pand.TariefKalender.GetTariefTypeVoorDatum(nacht);

                _prijsOfferte.Add(_pand.TarievenLijst[t]);
                _prijsOfferte.Add(staffelkorting.GetConcretePromotieOp(_pand.TarievenLijst[t]));
            }
        }
    }
}
