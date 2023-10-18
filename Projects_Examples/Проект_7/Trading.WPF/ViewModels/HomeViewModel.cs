using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.WPF.ViewModels;

public class HomeViewModel : BaseViewModel {

    public MajorIndexViewModel MajorIndexViewModel { get; set; }

    public HomeViewModel(MajorIndexViewModel majorIndexViewModel) {
        MajorIndexViewModel = majorIndexViewModel;
    }
}
