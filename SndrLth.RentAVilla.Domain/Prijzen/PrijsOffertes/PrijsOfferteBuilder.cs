using System.Linq;

namespace SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes
{
    public class PrijsOfferteBuilder
    {
        private readonly PrijsOfferte _prijsOfferte;
        private readonly Promoties.Promoties _promoties;
        private Reservatie _reservatie;

        public PrijsOfferteBuilder(Promoties.Promoties promoties)
        {
            _promoties = promoties;

            _prijsOfferte = new PrijsOfferte();
        }

        public PrijsOfferte GetPrijsOfferte(Reservatie reservatie)
        {
            _reservatie = reservatie;
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
            _prijsOfferte.Add(_reservatie.Pand.PersoonsToeslagPerNacht, _reservatie.ReservatiePeriode.AantalNachten, _reservatie.AantalPersonen);
            _prijsOfferte.Add(_reservatie.Pand.SchoonmaakPrijs);
            _prijsOfferte.Add(_reservatie.Pand.Waarborg);

        }

        private void AddHuurpijsEnStaffelRegels()
        {
            var staffelkorting =
                _reservatie.Klant.Categorie.Staffelkorting.StaffelTrancheLijst
                    .Where(
                        el => el.MinimumAantalNachten <= _reservatie.ReservatiePeriode.AantalNachten)
                    .Max().TrancheKorting;
            foreach (var nacht in _reservatie.ReservatiePeriode.GetNachten())
            {
                var t = _reservatie.Pand.TariefKalender.GetTariefTypeVoorDatum(nacht);

                _prijsOfferte.Add(_reservatie.Pand.TarievenLijst[t]);
                _prijsOfferte.Add(staffelkorting.GetConcretePromotieOp(_reservatie.Pand.TarievenLijst[t]));
            }
        }
    }
}