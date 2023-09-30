using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.Models;
using StartUpMVVM.Services;
using StartUpMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StartUpMVVM.ViewModels;

internal class CountriesStatisticViewModel : ViewModel {

    private DataService _dataService;
    private MainWindowViewModel MainModel { get; }

    #region _Countries - Статистика по странам

    /// <summary> Статистика по странам </summary>
    private IEnumerable<CountryInfo> _Countries;

    /// <summary> Статистика по странам </summary>
    public IEnumerable<CountryInfo> Countries {
        get => _Countries;
        private set => Set(ref _Countries, value);
    }

    #endregion

    #region Команды

    public ICommand RefreshDataCommand { get; }

    private void OnRefreshDataCommandExecuted(object p) {
        Countries = _dataService.GetData();            
    }

    #endregion

    public CountriesStatisticViewModel(MainWindowViewModel mainModel) {
        MainModel = mainModel;
        _dataService = new DataService();

        RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
    }
}
