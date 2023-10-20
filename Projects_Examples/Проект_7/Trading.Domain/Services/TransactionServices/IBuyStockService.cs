using Trading.Domain.Models;

namespace Trading.Domain.Services.TransactionServices;

/// <summary> Интерфейс представляющий логику покупки акции </summary>
public interface IBuyStockService {
    Task<Account> BuyStock(Account buyer, string symbol, int shares);
}
