using System.ComponentModel;

namespace Trading.WPF.ViewModels;

public interface ISearchSymbolViewModel : INotifyPropertyChanged {
    string ErrorMessage { set; }
    string SearchResultSymbol { set; }
    double StockPrice { set; }
    string Symbol { get; }
    bool CanSearchSymbol { get; }
}
