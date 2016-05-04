using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class CityListVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ICityDistanceServiceWrapper cityDistanceService;
        #endregion

        #region Properties & BackFields

        //private ObservableCollection<City> cities;

        //public ObservableCollection<City> Cities
        //{
        //    get { return cities; }
        //    set { this.SetField(p=>p.Cities,ref cities,value);}
        //}
        private ObservableCollection<City> sourceCities;

        public ObservableCollection<City> SourceCities
        {
            get { return sourceCities; }
            set { this.SetField(p => p.SourceCities, ref sourceCities, value); }
        }
        private ObservableCollection<City> destinationCities;

        public ObservableCollection<City> DestinationCities
        {
            get { return destinationCities; }
            set { this.SetField(p => p.DestinationCities, ref destinationCities, value); }
        }
        private City selectedSourceCity;

        public City SelectedSourceCity
        {
            get { return selectedSourceCity; }
            set { this.SetField(p => p.SelectedSourceCity, ref selectedSourceCity, value); }
        }
        private City selectedDestinationCity;

        public City SelectedDestinationCity
        {
            get { return selectedDestinationCity; }
            set { this.SetField(p => p.SelectedDestinationCity, ref selectedDestinationCity, value); }
        }
        #endregion

        #region Constructors

        public CityListVM()
        {
            init();
        }

        public CityListVM(IRMSController controller, ICityDistanceServiceWrapper cityDistanceService)
        {
            this.controller = controller;
            this.cityDistanceService = cityDistanceService;
        }

        #endregion

        #region Private Methods
        public void init()
        {
            DisplayName = "فاصله شهر ها";
            SourceCities=new ObservableCollection<City>();
            DestinationCities=new ObservableCollection<City>();
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
            cityDistanceService.GetAllSourceCity(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SourceCities= new ObservableCollection<City>(res);
                    }
                    else controller.HandleException(exp);
                });
            cityDistanceService.GetAllDestinationCity(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        DestinationCities = new ObservableCollection<City>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
