using Microsoft.Extensions.DependencyInjection;

namespace TestTemplateMVVM.ViewModels;

internal class ViewModelLocator {
    public MainWindowViewModel MainWindowModel => 
        App.Services.GetRequiredService<MainWindowViewModel>();
}
