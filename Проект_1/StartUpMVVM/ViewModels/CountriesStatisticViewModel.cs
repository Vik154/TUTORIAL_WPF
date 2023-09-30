using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.Models;
using StartUpMVVM.Services;
using StartUpMVVM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace StartUpMVVM.ViewModels;

internal class CountriesStatisticViewModel : ViewModel {

    private DataService _dataService;

    public MainWindowViewModel MainModel { get; set; }

    #region _Countries - Статистика по странам

    /// <summary> Статистика по странам </summary>
    private IEnumerable<CountryInfo> _Countries;

    /// <summary> Статистика по странам </summary>
    public IEnumerable<CountryInfo> Countries {
        get => _Countries;
        private set => Set(ref _Countries, value);
    }

    #endregion

    #region SelectedCountry : CountryInfo - Выбранная страна

    /// <summary>Выбранная страна</summary>
    private CountryInfo _SelectedCountry;

    /// <summary>Выбранная страна</summary>
    public CountryInfo SelectedCountry { 
        get => _SelectedCountry; 
        set => Set(ref _SelectedCountry, value); 
    }

    #endregion

    #region Команды

    public ICommand RefreshDataCommand { get; }

    private void OnRefreshDataCommandExecuted(object p) {
        MessageBox.Show("Отработала");
        Countries = _dataService.GetData();
    }

    public ICommand Test { get; }

    private void OnTest(object p) => MessageBox.Show("TestCommand OK");
    private bool CanTest(object p) => true;

    #endregion

    public CountriesStatisticViewModel(MainWindowViewModel mainModel) {
        
        MainModel = mainModel;

        _dataService = new DataService();

        RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

        Test = new LambdaCommand(OnTest, CanTest);
    }

    /// <summary> Отладочный конструктор, используемый в процессе разработки в визуальном конструкторе</summary>
    public CountriesStatisticViewModel() : this(null) {
        if (!App.IsDesignModel)
            throw new InvalidOperationException("Вызов конструктора не предназначенного для использования");

        _Countries = Enumerable.Range(1, 10)
            .Select(i => new CountryInfo {
                Name = $"Country {i}",

                Provinces = Enumerable.Range(1, 10).Select(j => new PlaceInfo {
                    Name = $"Province {i}",
                    Location = new System.Windows.Point(i, j),

                    Counts = Enumerable.Range(1, 10).Select(k => new ConfirmedCount {
                        Date = DateTime.Now.Subtract(TimeSpan.FromDays(100 - k)),
                        Count = k
                    }).ToArray()
                }).ToArray()
            }).ToArray();
    }
}
