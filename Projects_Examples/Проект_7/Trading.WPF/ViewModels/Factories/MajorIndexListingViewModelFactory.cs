using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Services;

namespace Trading.WPF.ViewModels.Factories;

public class MajorIndexListingViewModelFactory : ISimpleTraderViewModelFactory<MajorIndexListingViewModel> {
    
    private readonly IMajorIndexService _majorIndexService;

    public MajorIndexListingViewModelFactory(IMajorIndexService majorIndexService) {
        _majorIndexService = majorIndexService;
    }

    public MajorIndexListingViewModel CreateViewModel() {
        return MajorIndexListingViewModel.LoadMajorIndexViewModel(_majorIndexService);
    }
}
