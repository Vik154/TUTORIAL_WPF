using System.Windows.Input;
using Trading.Domain.Services;
using Trading.Domain.Services.TransactionServices;
using Trading.WPF.Commands;
using Trading.WPF.State.Accounts;

namespace Trading.WPF.ViewModels;

public class BuyViewModel : BaseViewModel, ISearchSymbolViewModel {
    private string _symbol;
    public string Symbol {
        get {
            return _symbol;
        }
        set {
            _symbol = value;
            OnPropertyChanged(nameof(Symbol));
            OnPropertyChanged(nameof(CanSearchSymbol));
        }
    }

    public bool CanSearchSymbol => !string.IsNullOrEmpty(Symbol);

    private string _searchResultSymbol = string.Empty;
    public string SearchResultSymbol {
        get {
            return _searchResultSymbol;
        }
        set {
            _searchResultSymbol = value;
            OnPropertyChanged(nameof(SearchResultSymbol));
        }
    }

    private double _stockPrice;
    public double StockPrice {
        get {
            return _stockPrice;
        }
        set {
            _stockPrice = value;
            OnPropertyChanged(nameof(StockPrice));
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    private int _sharesToBuy;
    public int SharesToBuy {
        get {
            return _sharesToBuy;
        }
        set {
            _sharesToBuy = value;
            OnPropertyChanged(nameof(SharesToBuy));
            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(CanBuyStock));
        }
    }

    public bool CanBuyStock => SharesToBuy > 0;

    public double TotalPrice {
        get {
            return SharesToBuy * StockPrice;
        }
    }

    public MessageViewModel ErrorMessageViewModel { get; }

    public string ErrorMessage {
        set => ErrorMessageViewModel.Message = value;
    }

    public MessageViewModel StatusMessageViewModel { get; }

    public string StatusMessage {
        set => StatusMessageViewModel.Message = value;
    }

    public ICommand SearchSymbolCommand { get; set; }
    public ICommand BuyStockCommand { get; set; }

    public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService, IAccountStore accountStore) {
        ErrorMessageViewModel = new MessageViewModel();
        StatusMessageViewModel = new MessageViewModel();

        SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
        BuyStockCommand = new BuyStockCommand(this, buyStockService, accountStore);
    }

    public override void Dispose() {
        ErrorMessageViewModel.Dispose();
        StatusMessageViewModel.Dispose();

        base.Dispose();
    }
}

//public class BuyViewModel : BaseViewModel {

//    private string _symbol;
//    public string Symbol {
//        get => _symbol; 
//        set { _symbol = value; OnPropertyChanged(nameof(Symbol)); }
//    }

//    private double _stockPrice;
//    public double StockPrice {
//        get => _stockPrice;
//        set { 
//            _stockPrice =  value; 
//            OnPropertyChanged(nameof(StockPrice));
//            OnPropertyChanged(nameof(TotalPrice));
//        }
//    }

//    private int _sharesToBuy;
//    public int SharesToBuy {
//        get => _sharesToBuy;
//        set { 
//            _sharesToBuy = value; 
//            OnPropertyChanged(nameof(SharesToBuy));
//            OnPropertyChanged(nameof(TotalPrice));
//        }
//    }

//    public double TotalPrice {
//        get => SharesToBuy * StockPrice;
//    }

//    private string _searchResultSymbol = string.Empty;
//    public string SearchResultSymbol {
//        get => _searchResultSymbol;
//        set { 
//            _searchResultSymbol = value;
//            OnPropertyChanged(nameof(SearchResultSymbol));
//        }
//    }

//    public ICommand SearchSymbolCommand { get; set; }
//    public ICommand BuyStockCommand { get; set; }

//    public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
//    {
//        SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
//        BuyStockCommand = new BuyStockCommand(this, buyStockService);
//    }
//}
