using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RestauracjaB : DatabaseClass//dziedziczy po databaseclass bo bedzie uzywala bazy danych
    {
        #region Constructor
        public RestauracjaB(HotelEntities hotelEntities)
            : base(hotelEntities)
        {
        }
        #endregion
        #region ViewFunction
        //metoda pobierze wszystkie towary do comboboxa
        public IQueryable<ComboBoxKeyAndValue> GetNapojeComboBoxItems()
        {
            return
                (
                    from posilek in hotelEntities.RodzajeNapojow
                    select new ComboBoxKeyAndValue
                    {
                        Key = posilek.IdRodzajuNapoju,
                        Value = posilek.Nazwa ,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
