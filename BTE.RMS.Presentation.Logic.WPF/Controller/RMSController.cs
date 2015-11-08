using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Presentation.Logic.WPF.Controller
{
    public class RMSController:IRMSController
    {
        public void ShowMainWindow()
        {
            
        }

        #region Public 
        public void BeginInvokeOnDispatcher(Action action)
        {
            throw new NotImplementedException();
        }

        public void HandleException(Exception exp)
        {
            throw new NotImplementedException();
        }

        public void Close(WorkspaceViewModel workspaceViewModel)
        {
            throw new NotImplementedException();
        } 
        #endregion


    }
}
