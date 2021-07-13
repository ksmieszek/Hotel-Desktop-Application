using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class EmailViewModel : WorkspaceViewModel
    {
        #region Konstruktor
        public EmailViewModel()
        {
            base.DisplayName = "Skrzynka email"; 
        }
        #endregion
    }
}
