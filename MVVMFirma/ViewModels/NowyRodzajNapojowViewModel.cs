using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyRodzajNapojowViewModel : JedenViewModel<RodzajeNapojow>
    {
        #region Constructor
        public NowyRodzajNapojowViewModel()
            : base()
        {
            base.DisplayName = "Nowy typ napoju";
            item = new RodzajeNapojow();
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
            hotelEntities.RodzajeNapojow.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
