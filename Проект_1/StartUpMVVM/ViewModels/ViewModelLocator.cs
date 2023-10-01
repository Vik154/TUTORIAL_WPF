using Microsoft.Extensions.DependencyInjection;


namespace StartUpMVVM.ViewModels;

// Класс - за счет которого осуществляется доступ к определенным ViewModels
internal class ViewModelLocator {

    public MainWindowViewModel MainWindowModel => 
        App.Host.Services.GetRequiredService<MainWindowViewModel>();

    //public StudentsManagementViewModel StudentManagement => 
    //    App.Host.Services.GetRequiredService<StudentsManagementViewModel>();
}
