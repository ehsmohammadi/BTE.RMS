using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class CityDistanceVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ICityDistanceServiceWrapper cityDistanceService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<City> cities;

        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set { this.SetField(p => p.Cities, ref cities, value); }
        }

        private City selectedSourceCity;
        public City SelectedSourceCity
        {
            get { return selectedSourceCity; }
            set
            {
                this.SetField(p => p.SelectedSourceCity, ref selectedSourceCity, value);
            }
        }

        private City selectedDestinationCity;
        public City SelectedDestinationCity
        {
            get { return selectedDestinationCity; }
            set
            {
                this.SetField(p => p.SelectedDestinationCity, ref selectedDestinationCity, value);
            }
        }

        #endregion

        #region Constructors

        public CityDistanceVM(IRMSController controller,ICityDistanceServiceWrapper cityDistanceService)
        {
            this.controller = controller;
            this.cityDistanceService = cityDistanceService;
            init();
        }

        public CityDistanceVM()
        {
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "فاصله شهرهای کشور";
            Cities = new ObservableCollection<City>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        #endregion

        #region Public Methods
        public void Load()
        {
            cityDistanceService.GetAllCityDistanceServiceList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Cities = new ObservableCollection<City>(res);
                    }
                    else controller.HandleException(exp);
                });
        }

        #endregion
    }
}
