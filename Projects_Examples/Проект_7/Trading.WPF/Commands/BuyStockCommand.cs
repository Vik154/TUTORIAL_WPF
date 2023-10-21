using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Trading.Domain.Models;
using Trading.Domain.Services.TransactionServices;
using Trading.WPF.ViewModels;

namespace Trading.WPF.Commands;

public class BuyStockCommand : ICommand {

    public event EventHandler? CanExecuteChanged;

    private BuyViewModel _buyViewModel;
    private IBuyStockService _buyStockService;

    public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService) {
        _buyViewModel = buyViewModel;
        _buyStockService = buyStockService;
    }

    public bool CanExecute(object? parameter) => true;

    public async void Execute(object? parameter) {
        try {
            await _buyStockService.BuyStock(new Domain.Models.Account {
                Id = 1,
                Balance = 500,
                AssetTransactions = new List<AssetTransaction>()
            }, _buyViewModel.Symbol, _buyViewModel.SharesToBuy);
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
    }
}
