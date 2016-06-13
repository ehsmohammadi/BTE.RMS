using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.Controller;
using System.Windows;
using System.Globalization;
namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class PooyaMenuVM:WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        #endregion

        #region Properties

        private bool selective;
        public bool Selective
        {
            get
            {
                return selective;
            }
            set
            {
                this.selective = value;
                OnPropertyChanged("Selective");
            }
        }

        public CommandViewModel SelectMenu
        {
            get
            {
                return new CommandViewModel("منوی روزانه", new DelegateCommand(Selectmenu));
            }
        }

        public CommandViewModel HideMenu
        {
            get
            {
                return new CommandViewModel("منوی روزانه", new DelegateCommand(Hidemenu));
            }
        }
        #endregion

        #region Constructors
        public PooyaMenuVM()
        {
            init();
        }

        public PooyaMenuVM(IRMSController rms)
        {
            this.controller = rms;
        }
        #endregion

        #region Private Methods
        private void init(){
        }
        
        private void Selectmenu()
        {
            Selective = true;
        }

        private void Hidemenu()
        {
            Selective = false;
        }

        #endregion     

        #region Public Method
        public void Load()
        {

        }
        #endregion

    }
}
