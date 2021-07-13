using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;

namespace MVVMFirma.ViewModels
{
    class WszystkieStanowiskaViewModel : WszystkieViewModel<Stanowiska>
    {
        #region Constructor
        public WszystkieStanowiskaViewModel()
            : base()
        {
            base.DisplayName = "Stanowiska";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Stanowiska>(hotelEntities.Stanowiska);
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Stanowiska>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<Stanowiska>(List.OrderBy(item => item.Opis));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<Stanowiska>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Stanowiska>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
