using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trading.Domain.Services;
using Trading.Domain.Services.TransactionServices;
using Trading.WPF.Commands;

namespace Trading.WPF.ViewModels;

public class BuyViewModel : BaseViewModel {

    private string _symbol;
    public string Symbol {
        get => _symbol; 
        set { _symbol = value; OnPropertyChanged(nameof(Symbol)); }
    }

    private double _stockPrice;
    public double StockPrice {
        get => _stockPrice;
        set { 
            _stockPrice =  value; 
            OnPropertyChanged(nameof(StockPrice));
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    private int _sharesToBuy;
    public int SharesToBuy {
        get => _sharesToBuy;
        set { 
            _sharesToBuy = value; 
            OnPropertyChanged(nameof(SharesToBuy));
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    public double TotalPrice {
        get => SharesToBuy * StockPrice;
    }

    private string _searchResultSymbol = string.Empty;
    public string SearchResultSymbol {
        get => _searchResultSymbol;
        set { 
            _searchResultSymbol = value;
            OnPropertyChanged(nameof(SearchResultSymbol));
        }
    }

    public ICommand SearchSymbolCommand { get; set; }
    public ICommand BuyStockCommand { get; set; }

    public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
    {
        SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
        BuyStockCommand = new BuyStockCommand(this, buyStockService);
    }
}
