namespace Trading.Domain.Services;

public interface IStockPriceService {
    Task<double> GetPrice(string symbol);
}
