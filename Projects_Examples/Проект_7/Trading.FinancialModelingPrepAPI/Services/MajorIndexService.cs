using Newtonsoft.Json;
using Trading.Domain.Models;
using Trading.Domain.Services;

namespace Trading.FinancialModelingPrepAPI.Services;

/// <summary> Класс по работе с api для получения биржевых данных </summary>
public class MajorIndexService : IMajorIndexService {
    public async Task<object> GetMajorIndex(MajorIndexType indexType) {
        
        using (HttpClient client = new HttpClient()) {
            HttpResponseMessage response =
                // await client.GetAsync("https://financialmodelingprep.com/api/v3/majors-indexes/.DJI");
                await client.GetAsync("https://iss.moex.com/iss/history/engines/stock/markets/index/boards/RTSI/securities/RTSSM.json?from=2023-10-16");
        
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
            var majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);

            // return majorIndex;
            return majorIndex;
        }    
    }

    Task<MajorIndex> IMajorIndexService.GetMajorIndex(MajorIndexType indexType) {
        throw new NotImplementedException();
    }
}
