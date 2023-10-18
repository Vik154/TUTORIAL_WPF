using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Models;
using Trading.Domain.Services;

namespace Trading.WPF.ViewModels;

/// <summary> Модель - представление биржевых индексов </summary>
public class MajorIndexViewModel {

    private readonly IMajorIndexService _majorIndexService;

    public MajorIndex RTS {  get; set; }
    public MajorIndex MOEX { get; set;}

    public MajorIndexViewModel(IMajorIndexService majorIndexService) {
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

    public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService) {
        MajorIndexViewModel majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
        majorIndexViewModel.LoadMajorIndexes();
        return majorIndexViewModel;
    }
}
