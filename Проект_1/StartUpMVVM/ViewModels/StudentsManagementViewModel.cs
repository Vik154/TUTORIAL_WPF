using StartUpMVVM.ViewModels.Base;

namespace StartUpMVVM.ViewModels;

class StudentsManagementViewModel : ViewModel {

    #region Title - заголовок окна
    /// <summary> Заголовок окна </summary>
    private string _Title = "Управление студентами";

    /// <summary> Заголовок окна </summary>
    public string Title {
        get => _Title;
        set => Set(ref _Title, value);
    }
    #endregion
}
