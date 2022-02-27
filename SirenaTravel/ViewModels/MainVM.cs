using System.Threading.Tasks;

using MvvmHelpers.Commands;

using SirenaTravel.Models;
using SirenaTravel.Services;

namespace SirenaTravel.ViewModels
{
    class MainVM : BaseVM
    {
        private Airport firstAirport;
        private Airport secondAirport;
        private double resultKilometers;
        private double resultMiles;
        private string firstInfo;
        private string secondInfo;
        private string firstIATA;
        private string secondIATA;

        private const string loading = "loading...";
        private const string dataLoaded = "data loaded";
        private const string dataLoadingError = "data loading error";

        private RequestsService requestsService;

        public MainVM()
        {
            requestsService = new RequestsService();
            FirstIATA = "KJA";
            SecondIATA = "SVO";
        }

        #region Commands
        private AsyncCommand commandGetFirstAirport;
        public AsyncCommand CommandGetFirstAirport => commandGetFirstAirport ?? (commandGetFirstAirport = new AsyncCommand(async () =>
        {
            FirstAirport = null;
            FirstInfo = loading;
            FirstAirport = await requestsService.GetAirportData(FirstIATA);
            FirstInfo = FirstAirport == null ?
            dataLoadingError : dataLoaded;
            ResultKilometers = 0;
            ResultMiles = 0;
        }));

        private AsyncCommand commandGetSecondAirport;
        public AsyncCommand CommandGetSecondAirport => commandGetSecondAirport ?? (commandGetSecondAirport = new AsyncCommand(async () =>
        {
            SecondAirport = null;
            SecondInfo = loading;
            SecondAirport = await requestsService.GetAirportData(SecondIATA);
            SecondInfo = SecondAirport == null ?
            dataLoadingError : dataLoaded;
            ResultKilometers = 0;
            ResultMiles = 0;
        }));

        private AsyncCommand commandGetAllAirports;
        public AsyncCommand CommandGetAllAirports => commandGetAllAirports ?? (commandGetAllAirports = new AsyncCommand(async () =>
        {
            FirstAirport = null;
            FirstInfo = loading;
            SecondAirport = null;
            SecondInfo = loading;

            var tasks = new Task<Airport>[]
            {
                requestsService.GetAirportData(FirstIATA),
                requestsService.GetAirportData(SecondIATA)
            };

            var airports = await Task.WhenAll(tasks);

            FirstAirport = airports[0];
            SecondAirport = airports[1];
            FirstInfo = FirstAirport == null ?
            dataLoadingError : dataLoaded;
            SecondInfo = SecondAirport == null ?
            dataLoadingError : dataLoaded;
            ResultKilometers = 0;
            ResultMiles = 0;
        }));

        private Command commandCalculate;
        public Command CommandCalculate => commandCalculate ?? (commandCalculate = new Command(() =>
        {
            if (FirstAirport != null && SecondAirport != null)
            {
                var lonA = FirstAirport.location.lon;
                var latA = FirstAirport.location.lat;
                var lonB = SecondAirport.location.lon;
                var latB = secondAirport.location.lat;

                ResultKilometers = Calculator.DistanceBetweenAirports(lonA, latA, lonB, latB);            
                ResultMiles = Calculator.KmToMiles(ResultKilometers);
            }
        }));
        #endregion Commands

        #region PROPERTIES
        public Airport FirstAirport
        {
            get => firstAirport;
            set
            {
                firstAirport = value;
                OnPropertyChanged(nameof(FirstAirport));
            }
        }
        public Airport SecondAirport
        {
            get => secondAirport;
            set
            {
                secondAirport = value;
                OnPropertyChanged(nameof(SecondAirport));
            }
        }

        public string FirstInfo
        {
            get => firstInfo;
            set
            {
                firstInfo = value;
                OnPropertyChanged(nameof(FirstInfo));
            }
        }
        public string SecondInfo
        {
            get => secondInfo;
            set
            {
                secondInfo = value;
                OnPropertyChanged(nameof(SecondInfo));
            }
        }

        public string FirstIATA
        {
            get => firstIATA;
            set
            {
                firstIATA = value;
                OnPropertyChanged(nameof(FirstIATA));
            }
        }
        public string SecondIATA
        {
            get => secondIATA;
            set
            {
                secondIATA = value;
                OnPropertyChanged(nameof(SecondIATA));
            }
        }
        public double ResultKilometers 
        {
            get => resultKilometers;
            set
            {
                resultKilometers = value;
                OnPropertyChanged(nameof(ResultKilometers));
            }
        }
        public double ResultMiles
        {
            get => resultMiles;
            set
            {
                resultMiles = value;
                OnPropertyChanged(nameof(ResultMiles));
            }
        }
        #endregion PROPERTIES
    }
}