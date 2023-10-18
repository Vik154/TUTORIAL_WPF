using Newtonsoft.Json.Linq;
using Trading.Domain.Exceptions;
using Trading.Domain.Services;
using Trading.FinancialModelingPrepAPI.Results;

namespace Trading.FinancialModelingPrepAPI.Services;

public class StockPriceService : IStockPriceService {

    public async Task<double> GetPrice(string symbol) {

        using (HttpClient client = new HttpClient()) {

            double StockPrice = 0d;

            try {
                string uri = $"https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities/{symbol}.json?iss.meta=off";

                HttpResponseMessage response = await client.GetAsync(uri);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(jsonResponse);

                StockPrice = (double)jObject.SelectToken("securities.data[0][15]");
            }
            catch (Exception ex) {
                // throw new Exception($"JSON - {ex.Message}");
            }

            StockPriceResult stockPriceResult = new StockPriceResult {
                Price = StockPrice
            };

            if (StockPrice == 0d)
                throw new InvalidSymbolException(symbol);

            return stockPriceResult.Price;
        }
    }
}
