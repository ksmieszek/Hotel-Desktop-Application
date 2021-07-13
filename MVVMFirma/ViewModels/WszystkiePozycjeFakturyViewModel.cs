using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePozycjeFakturyViewModel : WszystkieViewModel<PozycjaFakturyForAllView>
    {
        #region Constructor
        public WszystkiePozycjeFakturyViewModel()
        {
            base.DisplayName = "Pozycje faktury";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<PozycjaFakturyForAllView>
                (
                    from pozycjaFaktury in hotelEntities.PozycjeFaktury
                    select new PozycjaFakturyForAllView
                    {
                        FakturaNumer = pozycjaFaktury.Faktury.Numer,
                        UslugaKod = pozycjaFaktury.Uslugi.Kod,
                        UslugaNazwa = pozycjaFaktury.Uslugi.Nazwa,
                        UslugaRezerwacjaCena = pozycjaFaktury.Uslugi.Rezerwacje.Brutto,
                        UslugaPosilekCena = pozycjaFaktury.Uslugi.Posilki.Brutto,
                        Ilosc = pozycjaFaktury.Ilosc,
                        Cena = pozycjaFaktury.Cena,
                    }
                );

        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Cena za rezerwację", "Cena za posiłek" };
        }
        public override void Sort()
        {
            if (SortField == "Cena za rezerwację")
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderByDescending(item => item.UslugaRezerwacjaCena));
            if (SortField == "Cena za posiłek")
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderByDescending(item => item.UslugaPosilekCena));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Numer faktury" };
        }

        public override void Find()
        {
            if (FindField == "Numer faktury")
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(item => item.FakturaNumer != null && item.FakturaNumer.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
