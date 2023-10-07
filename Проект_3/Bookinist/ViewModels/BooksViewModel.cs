using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.ViewModels;

namespace Bookinist.ViewModels;

class BooksViewModel : ViewModel {
    private readonly IRepository<Book> booksRepository;

    public BooksViewModel(IRepository<Book> booksRepository) {
        this.booksRepository = booksRepository;
    }
}
