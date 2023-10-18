using Newtonsoft.Json.Linq;
using Trading.Domain.Models;
using Trading.Domain.Services;

namespace Trading.FinancialModelingPrepAPI.Services;

public class StockPriceService : IStockPriceService {
    public async Task<double> GetPrice(string symbol) {

        using (HttpClient client = new HttpClient()) {
            HttpResponseMessage response = await client.GetAsync(GetUriSuffix(indexType));

            string jsonResponse = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(jsonResponse);

            string indexName;
            double indexPrice;

            try {
                indexName = (string)jObject.SelectToken("history.data[0][1]");
                indexPrice = (double)jObject.SelectToken("history.data[0][6]");
            }
            catch (Exception ex) {
                throw new Exception($"JSON - {ex.Message}");
            }

            MajorIndex majorIndex = new MajorIndex {
                Type = indexType,
                IndexName = indexName ?? "ERORR_PARSE",
                Price = indexPrice,
                Changes = new Random().Next(-5, 5) + 0.2
            };


            return majorIndex;
        }
    }

}
