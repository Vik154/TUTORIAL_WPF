using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test_MOEX_API;


internal class Program {
    static async Task Main(string[] args) {
        
        Console.WriteLine("Hello, World!\n\n");

        Console.WriteLine("Result:");
        var res = await GetDataFromMoex();
        Console.WriteLine(res);
    }

    public static async Task<object> GetDataFromMoex() {

        using (HttpClient client = new HttpClient()) {
            HttpResponseMessage response =
                await client.GetAsync(@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/RTSI/securities/RTSSM.json?from=2023-10-16&iss.meta=off");

            string jsonResponse = await response.Content.ReadAsStringAsync();


            JObject jObject = JObject.Parse(jsonResponse);
            var columns = jObject["history"]["data"][1][1];
            var data = jObject["history"]["data"][0][0];

            string name = (string)jObject.SelectToken("history.data[0][0]");

            var style = jObject.GetValue("history");


            HttpResponseMessage httpResponseMoex =
                await client.GetAsync(@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/IMOEX.json?from=2023-10-16&iss.meta=off");

            string jsonResponseMoex = await httpResponseMoex.Content.ReadAsStringAsync();

            Console.WriteLine(jsonResponseMoex);

            JObject imoex_json = JObject.Parse(jsonResponseMoex);

            string name2 = (string)jObject.SelectToken("history.data[0][0]");


            return Tuple.Create(name, style, data);

            //RTS? rts = JsonConvert.DeserializeObject<RTS>(jsonResponse);
            //// var majorIndex = JsonConvert.DeserializeObject(jsonResponse);

            //if (rts != null) {
            //    Console.WriteLine($"{rts.Close} --- {rts.Open} --- {rts.Name}");
            //}

            //return rts;

            //JArray jArray = JArray.Parse(jsonResponse);

            //return new RTS();
        }
    }

}

public class RTS {
    public string? Name { get; set; }
    public double Close {  get; set; }
    public double Open { get; set; }
}

/*
 
 {
"history": {
        "columns": ["BOARDID", "SECID", "TRADEDATE", "SHORTNAME", "NAME", "CLOSE", "OPEN", "HIGH", "LOW", "VALUE", "DURATION", "YIELD", "DECIMALS", "CAPITALIZATION", "CURRENCYID", "DIVISOR", "TRADINGSESSION", "VOLUME"],
        "data": [
                ["RTSI", "RTSSM", "2023-10-16", "RTS SMID Index", "Индекс РТС средней и малой капитализации", 1008.84, 1008.84, 1008.84, 1008.84, 1509104.4258886143, 0, 0, 2, 485458619.3835762, "USD", 11298199.621700, "3", 29816368744.0000],
                ["RTSI", "RTSSM", "2023-10-17", "RTS SMID Index", "Индекс РТС средней и малой капитализации", 1006.76, 1006.76, 1006.76, 1006.76, 2697662.113174955, 0, 0, 2, 483163029.6963841, "USD", 11298199.621700, "3", 20529218175.0000]
        ]
}}
 */


/*
 Result:
{
"history": {
        "columns": ["BOARDID", "SECID", "TRADEDATE", "SHORTNAME", "NAME", "CLOSE", "OPEN", "HIGH", "LOW", "VALUE", "DURATION", "YIELD", "DECIMALS", "CAPITALIZATION", "CURRENCYID", "DIVISOR", "TRADINGSESSION", "VOLUME"],
        "data": [
                ["SNDX", "IMOEX", "2023-10-16", "Индекс МосБиржи", "Индекс МосБиржи", 3234.78, 3204.81, 3235.66, 3202.94, 65853279415.65, 0, 0, 2, 5647802341404.739, "RUB", 1745961295.972100, "3", null],
                ["SNDX", "IMOEX", "2023-10-17", "Индекс МосБиржи", "Индекс МосБиржи", 3247.15, 3239.37, 3252.55, 3228.11, 72231692204.35, 0, 0, 2, 5669395635284.174, "RUB", 1745961295.972100, "3", null]
        ]
}}
 */