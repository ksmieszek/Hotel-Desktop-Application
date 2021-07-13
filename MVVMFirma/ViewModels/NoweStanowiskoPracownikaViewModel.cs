using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NoweStanowiskoPracownikaViewModel : JedenViewModel<StanowiskaPracownikow>
    {
        #region Constructor
        public NoweStanowiskoPracownikaViewModel()
        {
            base.DisplayName = "Stanowisko pracownika";
            item = new StanowiskaPracownikow();
            DataOd = DateTime.Now;
        }
        #endregion
        #region Properties
        public int IdStanowiskaPracownika
        {
            get
            {
                return item.IdStanowiskaPracownika;
            }
            set
            {
                if (item.IdStanowiskaPracownika != value)
                {
                    item.IdStanowiskaPracownika = value;
                    base.OnPropertyChanged(() => IdStanowiskaPracownika);
                }
            }
        }
        public int? IdPracownika
        {
            get
            {
                return item.IdPracownika;
            }
            set
            {
                if (item.IdPracownika != value)
                {
                    item.IdPracownika = value;
                    base.OnPropertyChanged(() => IdPracownika);
                }
            }
        }
        public DateTime? DataOd
        {
            get
            {
                return item.DataOd;
            }
            set
            {
                if (item.DataOd != value)
                {
                    item.DataOd = value;
                    base.OnPropertyChanged(() => DataOd);
                }
            }
        }
        public DateTime? DataDo
        {
            get
            {
                return item.DataDo;
            }
            set
            {
                if (item.DataDo != value)
                {
                    item.DataDo = value;
                    base.OnPropertyChanged(() => DataDo);
                }
            }
        }
        public int? IdStanowiska
        {
            get
            {
                return item.IdStanowiska;
            }
            set
            {
                if (item.IdStanowiska != value)
                {
                    item.IdStanowiska = value;
                    base.OnPropertyChanged(() => IdStanowiska);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> StanowiskaComboBoxItems
        {
            get
            {
                return
                    (
                        from stanowisko in hotelEntities.Stanowiska
                        select new ComboBoxKeyAndValue
                        {
                            Key = stanowisko.IdStanowiska,
                            Value = stanowisko.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboBoxKeyAndValue> PracownikComboBoxItems
        {
            get
            {
                return
                    (
                        from pracownik in hotelEntities.Pracownicy
                        select new ComboBoxKeyAndValue
                        {
                            Key = pracownik.IdPracownika,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            hotelEntities.StanowiskaPracownikow.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
