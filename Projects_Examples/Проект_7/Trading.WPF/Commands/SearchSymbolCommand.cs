using System.ComponentModel;
using Trading.Domain.Exceptions;
using Trading.Domain.Services;
using Trading.WPF.ViewModels;

namespace Trading.WPF.Commands;

public class SearchSymbolCommand : AsyncCommandBase {
    private readonly ISearchSymbolViewModel _viewModel;
    private readonly IStockPriceService _stockPriceService;

    public SearchSymbolCommand(ISearchSymbolViewModel viewModel, IStockPriceService stockPriceService) {
        _viewModel = viewModel;
        _stockPriceService = stockPriceService;

        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
    }

    public override bool CanExecute(object parameter) {
        return _viewModel.CanSearchSymbol && base.CanExecute(parameter);
    }

    public override async Task ExecuteAsync(object parameter) {
        try {
            double stockPrice = await _stockPriceService.GetPrice(_viewModel.Symbol);

            _viewModel.SearchResultSymbol = _viewModel.Symbol.ToUpper();
            _viewModel.StockPrice = stockPrice;
        }
        catch (InvalidSymbolException) {
            _viewModel.ErrorMessage = "Symbol does not exist.";
        }
        catch (Exception) {
            _viewModel.ErrorMessage = "Failed to get symbol information.";
        }
    }

    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(ISearchSymbolViewModel.CanSearchSymbol)) {
            OnCanExecuteChanged();
        }
    }
}

//public class SearchSymbolCommand : ICommand {

//    private BuyViewModel _buyViewModel;
//    private IStockPriceService _stockPriceService;

//    public event EventHandler? CanExecuteChanged;

//    public SearchSymbolCommand(BuyViewModel viewModel, IStockPriceService stockPriceService) {
//        _buyViewModel = viewModel;
//        _stockPriceService = stockPriceService;
//    }

//    public bool CanExecute(object? parameter) => true;

//    public async void Execute(object? parameter) {
//        try {
//            double stockPrice = await _stockPriceService.GetPrice(_buyViewModel.Symbol);
//            _buyViewModel.SearchResultSymbol = _buyViewModel.Symbol.ToUpper();
//            _buyViewModel.StockPrice = stockPrice;
//        }
//        catch (Exception ex) {
//            MessageBox.Show(ex.Message);
//        }
//    }
//}
