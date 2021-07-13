using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieNapojeViewModel : WszystkieViewModel<NapojForAllView>
    {
        #region Properties
        private NapojForAllView _WybranyNapoj;
        public NapojForAllView WybranyNapoj
        {
            get
            {
                return _WybranyNapoj;
            }
            set
            {
                if (_WybranyNapoj != value)
                {
                    _WybranyNapoj = value;
                    Messenger.Default.Send(_WybranyNapoj);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkieNapojeViewModel()
        {
            base.DisplayName = "Napoje";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<NapojForAllView>
                (
                    from napoj in hotelEntities.Napoje
                    select new NapojForAllView
                    {
                        IdNapoju = napoj.IdNapoju,
                        Nazwa = napoj.Nazwa,
                        RodzajNapojuNazwa = napoj.RodzajeNapojow.Nazwa,
                        Cena = napoj.Cena,
                        Sklad = napoj.Sklad,
                        Opis = napoj.Opis,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Cena(rosnąco)", "Cena(malejąco)" };
        }
        public override void Sort()
        {
            if (SortField == "Cena(rosnąco)")
                List = new ObservableCollection<NapojForAllView>(List.OrderBy(item => item.Cena));
            if (SortField == "Cena(malejąco)")
                List = new ObservableCollection<NapojForAllView>(List.OrderByDescending(item => item.Cena));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa",  "Zawiera w składzie", "Rodzaj" };
        }
        public override void Find()
        {
            if (FindField == "Zawiera w składzie")
                List = new ObservableCollection<NapojForAllView>(List.Where(item => item.Sklad != null && item.Sklad.Contains(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<NapojForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Rodzaj")
                List = new ObservableCollection<NapojForAllView>(List.Where(item => item.RodzajNapojuNazwa != null && item.RodzajNapojuNazwa.StartsWith(FindTextBox)));
            
        }
        #endregion
    }
}
