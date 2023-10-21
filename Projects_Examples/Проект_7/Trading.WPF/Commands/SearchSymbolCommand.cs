using System.Windows;
using System.Windows.Input;
using Trading.Domain.Services;
using Trading.WPF.ViewModels;

namespace Trading.WPF.Commands;

public class SearchSymbolCommand : ICommand {

    private BuyViewModel _buyViewModel;
    private IStockPriceService _stockPriceService;

    public event EventHandler? CanExecuteChanged;

    public SearchSymbolCommand(BuyViewModel viewModel, IStockPriceService stockPriceService) {
        _buyViewModel = viewModel;
        _stockPriceService = stockPriceService;
    }

    public bool CanExecute(object? parameter) => true;

    public async void Execute(object? parameter) {
        try {
            double stockPrice = await _stockPriceService.GetPrice(_buyViewModel.Symbol);
            _buyViewModel.SearchResultSymbol = _buyViewModel.Symbol.ToUpper();
            _buyViewModel.StockPrice = stockPrice;
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
    }
}
