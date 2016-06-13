using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.Controller;

namespace BTE.RMS.Presentation.Logic.ViewModels.Window
{
    public class WindowVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly ISyncService syncService;

        #endregion

        #region Constructor

        public WindowVM()
        {
            DisplayName = "قرار";

        }

        public WindowVM(IRMSController controller,ISyncService syncService)
        {
            this.controller = controller;
            this.syncService = syncService;
            DisplayName = "قرار";
        }

        #endregion


    }
}
