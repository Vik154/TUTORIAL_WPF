using StartUpMVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

}
