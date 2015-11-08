using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Presentation.Logic.WPF.Controller
{
    public interface IRMSController
    {
        void BeginInvokeOnDispatcher(Action action);
        void HandleException(Exception exp);
        void Close(WorkspaceViewModel workspaceViewModel);
        void ShowMainWindow();
    }
}
