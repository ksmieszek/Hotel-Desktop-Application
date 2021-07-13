using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowyNapojViewModel : JedenViewModel<Napoje>
    {
        #region Constructor
        public NowyNapojViewModel()
        {
            base.DisplayName = "Napoj";
            item = new Napoje();
        }
        #endregion
        #region Properties
        public int IdNapoju
        {
            get
            {
                return item.IdNapoju;
            }
            set
            {
                if (item.IdNapoju != value)
                {
                    item.IdNapoju = value;
                    base.OnPropertyChanged(() => IdNapoju);
                }
            }
        }
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
        public string Sklad
        {
            get
            {
                return item.Sklad;
            }
            set
            {
                if (item.Sklad != value)
                {
                    item.Sklad = value;
                    base.OnPropertyChanged(() => Sklad);
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
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        public int? IdRodzajuNapoju
        {
            get
            {
                return item.IdRodzajuNapoju;
            }
            set
            {
                if (item.IdRodzajuNapoju != value)
                {
                    item.IdRodzajuNapoju = value;
                    base.OnPropertyChanged(() => IdRodzajuNapoju);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> RodzajNapojuComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from rodzaj in hotelEntities.RodzajeNapojow
                        select new ComboBoxKeyAndValue
                        {
                            Key = rodzaj.IdRodzajuNapoju,
                            Value = rodzaj.Nazwa //+ " " + rodzaj.Opis
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            hotelEntities.Napoje.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
