using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    class WszystkieRodzajeKlientowViewModel : WszystkieViewModel<RodzajeKlientow>
    {
        #region Constructor
        public WszystkieRodzajeKlientowViewModel()
            : base()
        {
            base.DisplayName = "Rodzaje klientów";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<RodzajeKlientow>(hotelEntities.RodzajeKlientow);
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Opis"};
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<RodzajeKlientow>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<RodzajeKlientow>(List.OrderBy(item => item.Opis));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<RodzajeKlientow>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<RodzajeKlientow>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
