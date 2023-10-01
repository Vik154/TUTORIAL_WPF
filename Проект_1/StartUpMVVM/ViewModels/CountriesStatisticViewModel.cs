using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.Models;
using StartUpMVVM.Services;
using StartUpMVVM.ViewModels.Base;
using System.Windows.Input;

namespace StartUpMVVM.ViewModels;

internal class CountriesStatisticViewModel : ViewModel {

    private DataService? _dataService;

    public MainWindowViewModel? MainModel { get; internal set; }

    #region _Countries - Статистика по странам

    /// <summary> Статистика по странам </summary>
    private IEnumerable<CountryInfo>? _Countries;

    /// <summary> Статистика по странам </summary>
    public IEnumerable<CountryInfo>? Countries {
        get => _Countries;
        private set => Set(ref _Countries, value);
    }

    #endregion

    #region SelectedCountry : CountryInfo - Выбранная страна

    /// <summary>Выбранная страна</summary>
    private CountryInfo? _SelectedCountry;

    /// <summary>Выбранная страна</summary>
    public CountryInfo? SelectedCountry { 
        get => _SelectedCountry; 
        set => Set(ref _SelectedCountry, value); 
    }
    #endregion

    #region Команды

    public ICommand RefreshDataCommand { get; }

    private void OnRefreshDataCommandExecuted(object p) {
        Countries = _dataService?.GetData();
    }
    #endregion

    public CountriesStatisticViewModel(DataService dataService) {

        _dataService = dataService;

        RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
    }
}
