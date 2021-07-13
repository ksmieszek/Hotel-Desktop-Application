using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyRodzajKlientowViewModel : JedenViewModel<RodzajeKlientow>
    {
        #region Constructor
        public NowyRodzajKlientowViewModel()
            : base()
        {
            base.DisplayName = "Nowy rodzaj klienta";
            item = new RodzajeKlientow();
        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            hotelEntities.RodzajeKlientow.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
