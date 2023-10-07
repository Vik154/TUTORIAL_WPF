using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.ViewModels;

namespace Bookinist.ViewModels;

class StatisticViewModel : ViewModel {
    private IRepository<Book> books;
    private IRepository<Buyer> buyers;
    private IRepository<Seller> sellers;

    public StatisticViewModel(IRepository<Book> books, IRepository<Buyer> buyers, IRepository<Seller> sellers) {
        this.books = books;
        this.buyers = buyers;
        this.sellers = sellers;
    }
}
