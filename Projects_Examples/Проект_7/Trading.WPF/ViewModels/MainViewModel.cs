using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels;

public class MainViewModel : BaseViewModel {

    public INavigator Navigator { get; set; } = new Navigator();
}
