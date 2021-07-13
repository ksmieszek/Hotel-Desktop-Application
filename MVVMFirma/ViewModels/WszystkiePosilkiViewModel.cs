using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePosilkiViewModel : WszystkieViewModel<PosilekForAllView>
    {
        #region Properties
        private PosilekForAllView _WybranyPosilek;
        public PosilekForAllView WybranyPosilek
        {
            get
            {
                return _WybranyPosilek;
            }
            set
            {
                if (_WybranyPosilek != value)
                {
                    _WybranyPosilek = value;
                    Messenger.Default.Send(_WybranyPosilek);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkiePosilkiViewModel()
        {
            base.DisplayName = "Posiłki";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<PosilekForAllView>
                (
                    from posilek in hotelEntities.Posilki
                    select new PosilekForAllView
                    {
                        IdPosilku = posilek.IdPosilku,
                        PotrawaNazwa = posilek.Potrawy.Nazwa,
                        NapojNazwa = posilek.Napoje.Nazwa,
                        IloscPotrawy = posilek.IloscPotrawy,
                        IloscNapoju = posilek.IloscNapoju,
                        DataZamowienia = posilek.DataZamowienia,
                        Netto = posilek.Netto,
                        VAT = posilek.VAT,
                        Rabat = posilek.Rabat,
                        Brutto = posilek.Brutto,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Cena(rosnąco)", "Cena(malejąco)", "Data zamówienia(najstarsza)", "Data zamówienia(najnowsza)" };
        }
        public override void Sort()
        {
            if (SortField == "Cena(rosnąco)")
                List = new ObservableCollection<PosilekForAllView>(List.OrderBy(item => item.Brutto));
            if (SortField == "Cena(malejąco)")
                List = new ObservableCollection<PosilekForAllView>(List.OrderByDescending(item => item.Brutto));
            if (SortField == "Data zamówienia(najstarsza)")
                List = new ObservableCollection<PosilekForAllView>(List.OrderBy(item => item.DataZamowienia));
            if (SortField == "Data zamówienia(najnowsza)")
                List = new ObservableCollection<PosilekForAllView>(List.OrderByDescending(item => item.DataZamowienia));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data zamówienia" };
        }
        public override void Find()
        {
            if (FindField == "Data zamówienia")
                List = new ObservableCollection<PosilekForAllView>(List.Where(item => item.DataZamowienia != null && System.DateTime.Equals(item.DataZamowienia, DateTime.Parse(FindTextBox))));
        }
        #endregion
    }
}
