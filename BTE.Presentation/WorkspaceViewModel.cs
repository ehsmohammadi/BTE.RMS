using System;
using System.Windows.Input;

namespace BTE.Presentation
{
    /// <summary>
    /// This ViewModelBase subclass requests to be removed 
    /// from the UI when its CloseCommand executes.
    /// This class is abstract.
    /// </summary>
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        #region Fields

        DelegateCommand closeCommand;
        Guid id;
        bool isBusy;
        private string busyMessage;

        #endregion // Fields

        #region Constructor

        protected WorkspaceViewModel()
        {
            id = Guid.NewGuid();
            BusyMessage = "در حال بارگذاری...";
        }

        #endregion // Constructor

        #region CloseCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new DelegateCommand(() => this.OnRequestClose());

                return closeCommand;
            }
        }

        #endregion // CloseCommand

        #region Id

        public Guid Id
        {
            get { return id; }
        }
        
        #endregion

        #region IView

        public IView View { get; set; }

        #endregion

        #region IsBusy
        public bool IsBusy
        {
            get { return isBusy; }
            set { this.SetField(vm => vm.IsBusy, ref isBusy, value); }
        }
        #endregion

        #region BusyMessage

        public string BusyMessage
        {
            get { return busyMessage; }
            set { this.SetField(vm => vm.BusyMessage, ref busyMessage, value); }
        }


        #endregion   

        public void ShowBusyIndicator(string message)
        {
            BusyMessage = message;
            IsBusy = true;
        }
        
        public void ShowBusyIndicator()
        {
            IsBusy = true;
        }

        public void HideBusyIndicator()
        {
            IsBusy = false;
        }
     
        #region RequestClose [event]

        /// <summary>
        /// Raised when this workspace should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        protected virtual void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion // RequestClose [event]
    }
}