using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trading.Domain.Models;
using Trading.Domain.Services;

namespace Trading.FinancialModelingPrepAPI.Services;

/// <summary> Класс по работе с api для получения биржевых данных </summary>
public class MajorIndexService : IMajorIndexService {
    public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType) {
        
        using (HttpClient client = new HttpClient()) {
            HttpResponseMessage response =
                //await client.GetAsync(@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/RTSI/securities/RTSSM.json?from=2023-10-16&iss.meta=off");
                // await client.GetAsync("https://financialmodelingprep.com/api/v3/majors-indexes/.DJI");
                // await client.GetAsync("https://iss.moex.com/iss/history/engines/stock/markets/index/boards/RTSI/securities/RTSSM.json?from=2023-10-16");
                await client.GetAsync(GetUriSuffix(indexType));

            string jsonResponse = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(jsonResponse);

            string indexName;
            double indexPrice;

            try {
                indexName = (string)jObject.SelectToken("history.data[0][0]");
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

    private string GetUriSuffix(MajorIndexType indexType) {
        switch (indexType) {
            case MajorIndexType.RTS:
                return @"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/RTSI/securities/RTSSM.json?from=2023-10-16&iss.meta=off";
            case MajorIndexType.MOEX:
                return @"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/IMOEX.json?from=2023-10-16&iss.meta=off";

            default:
                throw new Exception("MajorIndexType does not have a suffix defined.");
        }
    }
}
