using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : JedenViewModel<Adresy>, IDataErrorInfo
    {
        #region Constructor
        public NowyAdresViewModel()
            : base()
        {
            base.DisplayName = "Nowy adres";
            item = new Adresy();
        }
        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Kraj")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.Kraj);
                }
                if (name == "Wojewodztwo")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.Wojewodztwo);
                }
                if (name == "Miasto")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.Miasto);
                }
                if (name == "Ulica")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.Ulica);
                }
                if (name == "NumerBudynku")
                {
                    komunikat = Validators.SprawdzCzyTylkoCyfry(this.NumerBudynku);
                }
                if (name == "NumerLokalu")
                {
                    komunikat = Validators.SprawdzCzyTylkoCyfry(this.NumerLokalu);
                }
                if (name == "KodPocztowy")
                {
                    komunikat = Validators.SprawdzKodPocztowy(this.KodPocztowy);
                }

                return komunikat;
            }
        }

        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord, jezeli ta funkcja zwroci true rekord bedzie zapisywany, jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["Kraj"] == null && this["Wojewodztwo"] == null)
                return true;
            return false;
        }
        #endregion
        #region Properties
        public string Kraj
        {
            get
            {
                return item.Kraj;
            }
            set
            {
                if (item.Kraj != value)
                {
                    item.Kraj = value;
                    base.OnPropertyChanged(() => Kraj);
                }
            }
        }
        public string Wojewodztwo
        {
            get
            {
                return item.Wojewodztwo;
            }
            set
            {
                if (item.Wojewodztwo != value)
                {
                    item.Wojewodztwo = value;
                    base.OnPropertyChanged(() => Wojewodztwo);
                }
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                if (item.Miasto != value)
                {
                    item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NumerBudynku
        {
            get
            {
                return item.NumerBudynku;
            }
            set
            {
                if (item.NumerBudynku != value)
                {
                    item.NumerBudynku = value;
                    base.OnPropertyChanged(() => NumerBudynku);
                }
            }
        }
        public string NumerLokalu
        {
            get
            {
                return item.NumerLokalu;
            }
            set
            {
                if (item.NumerLokalu != value)
                {
                    item.NumerLokalu = value;
                    base.OnPropertyChanged(() => NumerLokalu);
                }
            }
        }
        public string Fax
        {
            get
            {
                return item.Fax;
            }
            set
            {
                if (item.Fax != value)
                {
                    item.Fax = value;
                    base.OnPropertyChanged(() => Fax);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            hotelEntities.Adresy.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
