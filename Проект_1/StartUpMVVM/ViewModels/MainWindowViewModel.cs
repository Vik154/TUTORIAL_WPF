using StartUpMVVM.Infrastructure.Commands;
using StartUpMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StartUpMVVM.ViewModels;

internal class MainWindowViewModel : ViewModel {

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

    public MainWindowViewModel() {

        #region Команды
        CloseApplicationCommand = new LambdaCommand(
                                        OnCloseApplicationCommandExecuted, 
                                        CanCloseApplicationCommandExecute);
        #endregion
    }
}
