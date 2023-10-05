using FileEncryptor.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptor.WPF.ViewModels;

internal class MainWindowViewModel : ViewModel {
    #region Title : string - Заголовок окна

    /// <summary>Заголовок окна</summary>
    private string _Title = "Шифратор";

    /// <summary>Заголовок окна</summary>
    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion
}
