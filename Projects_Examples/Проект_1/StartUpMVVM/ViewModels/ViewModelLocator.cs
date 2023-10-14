using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;


namespace StartUpMVVM.ViewModels;

// Класс - за счет которого осуществляется доступ к определенным ViewModels
internal class ViewModelLocator {

    public MainWindowViewModel MainWindowModel {
        get {
            try {
                return App.Host.Services.GetRequiredService<MainWindowViewModel>();
            }
            catch (Exception ex) { 
                Debug.WriteLine(ex.Message);
            }
            throw new Exception("Сервис не регистрируется");
        }
    }

    public StudentsManagementViewModel StudentsManagement =>
        App.Host.Services.GetRequiredService<StudentsManagementViewModel>();
}