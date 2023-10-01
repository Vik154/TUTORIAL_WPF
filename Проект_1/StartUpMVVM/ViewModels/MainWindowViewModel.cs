using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.Models;
using StartUpMVVM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace StartUpMVVM.ViewModels;


[MarkupExtensionReturnType(typeof(MainWindowViewModel))]
internal class MainWindowViewModel : ViewModel {

    /*------------------------------------------------------------------------------------*/

    public CountriesStatisticViewModel CountriesStatistic { get; }

    /*------------------------------------------------------------------------------------*/

    #region Тестовые данные для визуализации графиков

    /// <summary> Тестовые данные для визуализации графиков </summary>
    private IEnumerable<DataPoint>? _TestDataPoint;

    /// <summary> Тестовые данные для визуализации графиков </summary>
    public IEnumerable<DataPoint>? TestDataPoint {
        get => _TestDataPoint;
        set => Set(ref _TestDataPoint, value);
    }
    #endregion

    #region Заголовок Окна

    private string _Title = "Текст из ViewModel";

    /// <summary> Заголовок окна </summary>
    public string Title { 
        get => _Title;
        set => Set(ref _Title, value);
    }
    #endregion

    #region Статус программы
    /// <summary> Статус программы </summary>
    private string _Status = "Готов";

    /// <summary> Статус программы </summary>
    public string Status { 
        get => _Status; 
        set => Set(ref _Status, value);
    }
    #endregion

    /*------------------------------------------------------------------------------------*/

    #region Команды

    #region CloseApplicationCommand
    public ICommand CloseApplicationCommand { get; }

    // Выполняется, когда команда выполняется
    private void OnCloseApplicationCommandExecuted(object sender) {
        Application.Current.Shutdown();
    }

    // Доступна ли команда для выполнения
    private bool CanCloseApplicationCommandExecute(object sender) => true;
    #endregion

    #endregion

    /*------------------------------------------------------------------------------------*/

    public MainWindowViewModel(CountriesStatisticViewModel Statistic) {

        CountriesStatistic = Statistic;
        Statistic.MainModel = this;

        #region Команды
        CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        #endregion

        #region Генерация графика
        var data_points = new List<DataPoint>((int)(360 / 0.1));

        for (var x = 0d; x < 360d; x += 0.1) {
            const double to_rad = Math.PI / 180;
            var y = Math.Sin(x * to_rad);

            data_points.Add(new DataPoint { XValue = x, YValue = y });
        }
        TestDataPoint = data_points;
        #endregion
    }

}
