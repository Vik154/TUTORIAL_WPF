using System.ComponentModel;
using Trading.Domain.Exceptions;
using Trading.Domain.Models;
using Trading.Domain.Services.TransactionServices;
using Trading.WPF.State.Accounts;
using Trading.WPF.ViewModels;

namespace Trading.WPF.Commands;

public class BuyStockCommand : AsyncCommandBase {
    private readonly BuyViewModel _buyViewModel;
    private readonly IBuyStockService _buyStockService;
    private readonly IAccountStore _accountStore;

    public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService, IAccountStore accountStore) {
        _buyViewModel = buyViewModel;
        _buyStockService = buyStockService;
        _accountStore = accountStore;

        _buyViewModel.PropertyChanged += BuyViewModel_PropertyChanged;
    }

    public override bool CanExecute(object parameter) {
        return _buyViewModel.CanBuyStock && base.CanExecute(parameter);
    }

    public override async Task ExecuteAsync(object parameter) {
        _buyViewModel.StatusMessage = string.Empty;
        _buyViewModel.ErrorMessage = string.Empty;

        try {
            string symbol = _buyViewModel.Symbol;
            int shares = _buyViewModel.SharesToBuy;
            Account account = await _buyStockService.BuyStock(_accountStore.CurrentAccount, symbol, shares);

            _accountStore.CurrentAccount = account;

            _buyViewModel.StatusMessage = $"Successfully purchased {shares} shares of {symbol}.";
        }
        catch (InsufficientFundsException) {
            _buyViewModel.ErrorMessage = "Account has insufficient funds. Please transfer more money into your account.";
        }
        catch (InvalidSymbolException) {
            _buyViewModel.ErrorMessage = "Symbol does not exist.";
        }
        catch (Exception) {
            _buyViewModel.ErrorMessage = "Transaction failed.";
        }
    }

    private void BuyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(BuyViewModel.CanBuyStock)) {
            OnCanExecuteChanged();
        }
    }
}

//public class BuyStockCommand : ICommand {

//    public event EventHandler? CanExecuteChanged;

//    private BuyViewModel _buyViewModel;
//    private IBuyStockService _buyStockService;

//    public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService) {
//        _buyViewModel = buyViewModel;
//        _buyStockService = buyStockService;
//    }

//    public bool CanExecute(object? parameter) => true;

//    public async void Execute(object? parameter) {
//        try {
//            await _buyStockService.BuyStock(new Domain.Models.Account {
//                Id = 1,
//                Balance = 500,
//                AssetTransactions = new List<AssetTransaction>()
//            }, _buyViewModel.Symbol, _buyViewModel.SharesToBuy);
//        }
//        catch (Exception ex) {
//            MessageBox.Show(ex.Message);
//        }
//    }
//}
