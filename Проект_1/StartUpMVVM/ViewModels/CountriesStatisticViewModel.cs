using StartUpMVVM.Services;
using StartUpMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMVVM.ViewModels;

internal class CountriesStatisticViewModel : ViewModel {

    private DataService _dataService;

    private MainWindowViewModel MainModel { get; }

    public CountriesStatisticViewModel(MainWindowViewModel mainModel) {
        MainModel = mainModel;
        _dataService = new DataService();
    }
}
