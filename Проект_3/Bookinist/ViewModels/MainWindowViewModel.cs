using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using Bookinist.Services;
using Bookinist.Services.Interfaces;
using MathCore.ViewModels;


namespace Bookinist.ViewModels; 

class MainWindowViewModel : ViewModel {

    private readonly IRepository<Book> _BooksRepository;
    private readonly IRepository<Seller> _Sellers;
    private readonly IRepository<Buyer> _Buyers;
    private readonly ISalesService _SalesService;

    #region Title - заголовок окна
    /// <summary> Заголовок окна </summary>
    private string _Title = "Главное окно";

    /// <summary> Заголовок окна </summary>
    public string Title {
        get => _Title;
        set => Set(ref _Title, value);
    }
    #endregion

    public MainWindowViewModel(
        IRepository<Book> BooksRepository, 
        ISalesService SalesService,
        IRepository<Seller> Sellers,
        IRepository<Buyer> Buyers)     
    {
        _BooksRepository = BooksRepository;
        _SalesService = SalesService;
        _Sellers = Sellers;
        _Buyers = Buyers;

    }

    //private async void Test() {
    //    var deals_count = _SalesService.Deals.Count();

    //    var book = await _BooksRepository.GetAsync(5);
    //    var buyer = await _Buyers.GetAsync(3);
    //    var seller = await _Sellers.GetAsync(7);

    //    var deal = _SalesService.MakeADeal(book.Name, seller, buyer, 100m);

    //    var deals_count2 = _SalesService.Deals.Count();
    //}
}
