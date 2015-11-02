using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.Presentation
{
    public interface IViewManager
    {
        void BeginInvokeOnDispatcher(Action action);
    }
}
