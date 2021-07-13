using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DatabaseClass//ta klasa umozliwia dostep do bazy danych
    {
        #region Fields
        protected HotelEntities hotelEntities;
        #endregion
        #region Constructor
        public DatabaseClass(HotelEntities hotelEntities)
        {
            this.hotelEntities = hotelEntities;
        }
        #endregion
    }
}
