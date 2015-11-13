using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BTE.Presentation.Portable
{
    public class ContentPageViewBase : ContentPage, IView
    {

        public WorkspaceViewModel ViewModel
        {
            get
            {
                WorkspaceViewModel vm = null;
                if (BindingContext != null)
                {
                    vm = BindingContext as WorkspaceViewModel;
                }
                return vm;
            }
            set
            {
                if (BindingContext != value)
                {
                    BindingContext = value;
                    if (value != null)
                    {
                        value.View = this;
                    }
                }
            }
        }

    }
}
