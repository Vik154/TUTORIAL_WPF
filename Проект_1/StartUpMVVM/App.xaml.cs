using System.Configuration;
using System.Data;
using System.Windows;

namespace StartUpMVVM; 


public partial class App : Application {

    // Флаг выполнения - работает из exe или из дизайнера
    // для проверки виртуализации и нагрузки
    public static bool IsDesignModel { get; private set; } = true;

    protected override void OnStartup(StartupEventArgs e) {
        IsDesignModel = false;
        base.OnStartup(e);
    }
}
