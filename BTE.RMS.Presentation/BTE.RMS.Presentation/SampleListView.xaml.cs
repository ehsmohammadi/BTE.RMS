using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation.Portable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BTE.RMS.Presentation
{
    public partial class SampleListView : ContentPageViewBase
    {
        public SampleListView()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new calender { BindingContext = new CalenderVM() });
        }
    }
}
