using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.Models;
using StartUpMVVM.Models.Decanat;
using StartUpMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace StartUpMVVM.ViewModels;

internal class MainWindowViewModel : ViewModel {

    /*------------------------------------------------------------------------------------*/

    private readonly CountriesStatisticViewModel _CountriesStatistic;

    /*------------------------------------------------------------------------------------*/

    public ObservableCollection<Group> Groups { get; }

    #region Разнородные элементы

    public object[] CompositeCollection { get; }

    /// <summary> Элемент любого типа </summary>
    private object _SelectedCompositeValue;

    /// <summary> Элемент любого типа </summary>
    public object SelectedCompositeValue {
        get => _SelectedCompositeValue;
        set => Set(ref  _SelectedCompositeValue, value);
    }

    #endregion

    #region Выбранная группа

    /// <summary> Выбранная группа </summary>
    private Group _SelectedGroup;
    
    /// <summary> Выбранная группа </summary>
    public Group SelectedGroup {
        get => _SelectedGroup;
        set {
            if (!Set(ref _SelectedGroup, value)) return;
            _SelectedGroupStudents.Source = value?.Students;
            OnPropertyChanged(nameof(SelectedGroupStudents));
        }
    }

    private readonly CollectionViewSource _SelectedGroupStudents = new CollectionViewSource();

    public ICollectionView? SelectedGroupStudents => _SelectedGroupStudents?.View;

    private void OnStudentFiltred(object sender, FilterEventArgs e) {
        if (!(e.Item is Student student)) {
            e.Accepted = false;
            return;
        }

        var filter_text = _StudentFilterText;
        if (string.IsNullOrWhiteSpace(filter_text))
            return;

        if (student.Name is null || student.SurName is null || student.Patronymic is null) {
            e.Accepted = false;
            return;
        }

        if (student.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
        if (student.SurName.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
        if (student.Patronymic.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

        e.Accepted = false;
    }

    #endregion

    #region _StudentFilterText - Текст фильтра студентов

    /// <summary> Текст фильтра студентов </summary>
    private string _StudentFilterText;

    /// <summary> Текст фильтра студентов </summary>
    public string StudentFilterText {
        get => _StudentFilterText;
        set { 
            if (!Set(ref _StudentFilterText, value)) return;
            _SelectedGroupStudents.View.Refresh();
        }
    }

    #endregion

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

    #region Тестирование виртуализации, заполнение списка студентов

    public IEnumerable<Student> TestStudents => 
        Enumerable.Range(1, (App.IsDesignModel ? 10 : 100_000))
            .Select(i => new Student {
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}"
            });

    #endregion

    #region Работа с директориями - DirectoryViewModel

    public DirectoryViewModel DiskRootDir { get; } = new DirectoryViewModel("C:\\");

    /// <summary> Выбранная директория </summary>
    private DirectoryViewModel _SelectedDirectory;

    /// <summary> Выбранная директория </summary>
    public DirectoryViewModel SelectedDirectory {
        get => _SelectedDirectory;
        set => Set(ref _SelectedDirectory, value);
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

    #region CreateGroup and DeleteGroup - добавление и удаление групп

    public ICommand CreateGroupCommand { get; }

    private bool CanCreateGroupCommandExecute(object sender) => true;

    private void OnCreateGroupCommandExecuted(object sender) {
        var group_max_index = Groups.Count + 1;
        var new_group = new Group {
            Name = $"Группа {group_max_index}",
            Students = new ObservableCollection<Student>()
        };
        Groups.Add(new_group);
    }

    public ICommand DeleteGroupCommand { get; }

    private bool CanDeleteGroupCommandExecute(object sender) => 
        sender is Group group && Groups.Contains(group);

    private void OnDeleteGroupCommandExecuted(object sender) {
        if (!(sender is Group group)) return;
        var group_index = Groups.IndexOf(group);
        Groups.Remove(group);
        if (group_index < Groups.Count)
            SelectedGroup = Groups[group_index];
    }
    #endregion

    #endregion

    /*------------------------------------------------------------------------------------*/

    public MainWindowViewModel() {

        _CountriesStatistic = new CountriesStatisticViewModel(this);

        #region Команды
        CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
        CreateGroupCommand = new LambdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
        DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);
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

        #region CompositeCollection

        var data_list = new List<object>();
        var group = Groups[1];

        data_list.Add("Hello world");
        data_list.Add(99);
        data_list.Add(group);
        data_list.Add(group.Students[0]);

        CompositeCollection = data_list.ToArray();

        #endregion

        _SelectedGroupStudents.Filter += OnStudentFiltred;
    }

}
