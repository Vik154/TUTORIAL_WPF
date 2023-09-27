using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.Models;
using StartUpMVVM.Models.Decanat;
using StartUpMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StartUpMVVM.ViewModels;

internal class MainWindowViewModel : ViewModel {
    
    /*------------------------------------------------------------------------------------*/

    public ObservableCollection<Group> Groups { get; }

    /*------------------------------------------------------------------------------------*/

    #region Переключатель вкладок

    /// <summary> Переключатель вкладок </summary>
    private int _SelectedPageIndex;
    
    /// <summary> Переключатель вкладок </summary>
    public int SelectedPageIndex {
        get => _SelectedPageIndex;
        set => Set(ref _SelectedPageIndex, value);
    }

    #endregion

    #region Тестовые данные для визуализации графиков

    /// <summary> Тестовые данные для визуализации графиков </summary>
    private IEnumerable<DataPoint> _TestDataPoint;

    /// <summary> Тестовые данные для визуализации графиков </summary>
    public IEnumerable<DataPoint> TestDataPoint {
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
        
        // set {
        //      if (Equals(_Title, value))
        //          return;
        //      _Title = value;
        //      OnPropertyChanged();
        // }
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

    #region ChangeTabIndexCommand - переключение вкладок

    public ICommand ChangeTabIndexCommand {  get; }

    private bool CanChangeTabIndexCommandExecute(object sender) => _SelectedPageIndex >= 0;

    private void OnChangeTabIndexCommandExecuted(object sender) {
        if (sender is null) return;
        SelectedPageIndex += Convert.ToInt32(sender);
    }

    #endregion

    #endregion

    /*------------------------------------------------------------------------------------*/

    public MainWindowViewModel() {

        #region Команды
        CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, 
                                                    CanCloseApplicationCommandExecute);
        ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, 
                                                  CanChangeTabIndexCommandExecute);
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

        #region Заполнение коллекции студентов

        var student_index = 1;

        var students = Enumerable.Range(1, 10).Select(i => new Student {
            Name = $"Name {student_index}",
            SurName = $"SurName {student_index}",
            Patronymic = $"Patronymic {student_index++}",
            Birthday = DateTime.Now,
            Rating = 0
        });
        
        var groups = Enumerable.Range(1, 20).Select(i => new Group {
            Name = $"Группа {i}",
            Students = new ObservableCollection<Student>(students)
        });

        Groups = new ObservableCollection<Group>(groups);

        #endregion
    }
}
