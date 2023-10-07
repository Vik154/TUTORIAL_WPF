using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.ViewModels;

namespace Bookinist.ViewModels;

class BuyersViewModel : ViewModel {
    private readonly IRepository<Buyer> buyers;

    public BuyersViewModel(IRepository<Buyer> buyers) {
        this.buyers = buyers;
    }
}
