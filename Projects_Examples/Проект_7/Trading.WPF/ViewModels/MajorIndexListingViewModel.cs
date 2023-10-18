using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Models;
using Trading.Domain.Services;

namespace Trading.WPF.ViewModels;

/// <summary> Модель - представление биржевых индексов </summary>
public class MajorIndexListingViewModel : BaseViewModel {

    private readonly IMajorIndexService _majorIndexService;

    private MajorIndex _RTS;
    public MajorIndex RTS {
        get => _RTS;
        set {
            _RTS = value;
            OnPropertyChanged(nameof(RTS));
        }
    }

    public MajorIndex _MOEX;
    public MajorIndex MOEX {
        get => _MOEX; 
        set {
            _MOEX = value;
            OnPropertyChanged(nameof(MOEX));
        }
    }

    public MajorIndexListingViewModel(IMajorIndexService majorIndexService) {
        _majorIndexService = majorIndexService;
    }

    private void LoadMajorIndexes() {
        _majorIndexService.GetMajorIndex(MajorIndexType.RTS).ContinueWith(task => {
            if (task.Exception == null) { RTS = task.Result; }
        });
        _majorIndexService.GetMajorIndex(MajorIndexType.MOEX).ContinueWith(task => {
            if (task.Exception == null) { MOEX = task.Result; }
        });
    }

    public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService) {
        MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);
        majorIndexViewModel.LoadMajorIndexes();
        return majorIndexViewModel;
    }
}
