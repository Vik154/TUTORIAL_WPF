using Trading.Domain.Models;

namespace Trading.Domain.Services.TransactionServices;
public interface ISellStockService {
    Task<Account> SellStock(Account seller, string symbol, int shares);
}
