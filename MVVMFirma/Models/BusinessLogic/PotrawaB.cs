using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class PotrawaB : DatabaseClass//dziedziczy po databaseclass bo bedzie uzywala bazy danych
    {
        #region Constructor
        public PotrawaB(HotelEntities hotelEntities)
            : base(hotelEntities)
        {
        }
        #endregion
        #region ViewFunction
        //metoda pobierze wszystkie towary do comboboxa
        public IQueryable<ComboBoxKeyAndValue> GetPotrawyComboBoxItems()
        {
            return
                (
                    from potrawa in hotelEntities.Potrawy
                    select new ComboBoxKeyAndValue
                    {
                        Key = potrawa.IdPotrawy,
                        Value =  potrawa.Nazwa + " (" + potrawa.RodzajePotraw.Nazwa + ") - " + potrawa.Cena + "zł",
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
