using Newtonsoft.Json.Linq;
using Trading.FinancialModelingPrepAPI.Models;
using Trading.FinancialModelingPrepAPI.Results;

namespace Trading.FinancialModelingPrepAPI;

public class FinancialModelingPrepHttpClient {
    
    private readonly HttpClient _client;
    private readonly string _apiKey;
    public FinancialModelingPrepHttpClient(HttpClient client, FinancialModelingPrepAPIKey key) {
        _client = client;
        _apiKey = key.Key;
    }

    public async Task<StockPriceResult> GetStockAsync(string symbol) {

        double StockPrice = 0d;

        try {
            string uri = $"https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities/{symbol}.json?iss.meta=off";

            HttpResponseMessage response = await _client.GetAsync(uri);

            string jsonResponse = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(jsonResponse);

            StockPrice = (double)jObject.SelectToken("securities.data[0][15]");
        }
        catch (Exception ex) {
            throw new Exception($"JSON - {ex.Message}");
        }

        StockPriceResult stockPriceResult = new StockPriceResult {
            Price = StockPrice
        };

        return stockPriceResult;
    }
}
