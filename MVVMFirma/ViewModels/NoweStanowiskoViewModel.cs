using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NoweStanowiskoViewModel : JedenViewModel<Stanowiska>
    {
        #region Constructor
        public NoweStanowiskoViewModel()
            : base()
        {
            base.DisplayName = "Nowe stanowisko";
            item = new Stanowiska();//tworze puste stanowisko
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
            hotelEntities.Stanowiska.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
