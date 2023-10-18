using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.WPF.ViewModels;

public class HomeViewModel : BaseViewModel {

    public MajorIndexListingViewModel MajorIndexListingViewModel { get; set; }

    public HomeViewModel(MajorIndexListingViewModel majorIndexViewModel) {
        MajorIndexListingViewModel = majorIndexViewModel;
    }
}
