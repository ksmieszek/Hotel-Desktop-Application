using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePotrawyViewModel : WszystkieViewModel<PotrawyForAllView>
    {
        #region Properties
        private PotrawyForAllView _WybranaPotrawa;
        public PotrawyForAllView WybranaPotrawa
        {
            get
            {
                return _WybranaPotrawa;
            }
            set
            {
                if (_WybranaPotrawa != value)
                {
                    _WybranaPotrawa = value;
                    Messenger.Default.Send(_WybranaPotrawa);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkiePotrawyViewModel()
        {
            base.DisplayName = "Potrawy";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<PotrawyForAllView>
                (
                    from potrawa in hotelEntities.Potrawy
                    select new PotrawyForAllView
                    {
                        IdPotrawy = potrawa.IdPotrawy,
                        Nazwa = potrawa.Nazwa,
                        RodzajPotrawyNazwa = potrawa.RodzajePotraw.Nazwa,
                        Cena = potrawa.Cena,
                        Sklad = potrawa.Sklad,
                        Opis = potrawa.Opis,
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
                List = new ObservableCollection<PotrawyForAllView>(List.OrderBy(item => item.Cena));
            if (SortField == "Cena(malejąco)")
                List = new ObservableCollection<PotrawyForAllView>(List.OrderByDescending(item => item.Cena));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Zawiera w składzie" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<PotrawyForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Zawiera w składzie")
                List = new ObservableCollection<PotrawyForAllView>(List.Where(item => item.Sklad != null && item.Sklad.Contains(FindTextBox)));
        }
        #endregion
    }
}
