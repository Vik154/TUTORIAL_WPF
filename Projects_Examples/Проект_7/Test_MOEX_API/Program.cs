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
            //HttpResponseMessage response =
            //    await client.GetAsync(@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/RTSI/securities/RTSSM.json?from=2023-10-16&iss.meta=off");

            //string jsonResponse = await response.Content.ReadAsStringAsync();


            //JObject jObject = JObject.Parse(jsonResponse);
            //var columns = jObject["history"]["data"][1][1];
            //var data = jObject["history"]["data"][0][0];

            //string name = (string)jObject.SelectToken("history.data[0][0]");

            //var style = jObject.GetValue("history");


            //HttpResponseMessage httpResponseMoex =
            //    await client.GetAsync(@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/IMOEX.json?from=2023-10-16&iss.meta=off");

            //string jsonResponseMoex = await httpResponseMoex.Content.ReadAsStringAsync();

            //Console.WriteLine(jsonResponseMoex);

            //JObject imoex_json = JObject.Parse(jsonResponseMoex);

            //string name2 = (string)jObject.SelectToken("history.data[0][0]");

            /*-----------------------------------------------------------------*/
            HttpResponseMessage httpResponseMoex = await client.GetAsync(@"https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities/SBER.json?iss.meta=off");
            string jsonResponseMoex = await httpResponseMoex.Content.ReadAsStringAsync();
            
            JObject jObject = JObject.Parse(jsonResponseMoex);
            Console.WriteLine(jsonResponseMoex);

            string name2 = (string)jObject.SelectToken("securities.data[0][15]");

            // return Tuple.Create(name, style, data);
            return Tuple.Create("1", "2", "3");

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


/*
 
 Result:
{
"securities": {
        "columns": ["SECID", "BOARDID", "SHORTNAME", "PREVPRICE", "LOTSIZE", "FACEVALUE", "STATUS", "BOARDNAME", "DECIMALS", "SECNAME", "REMARKS", "MARKETCODE", "INSTRID", "SECTORID", "MINSTEP", "PREVWAPRICE", "FACEUNIT", "PREVDATE", "ISSUESIZE", "ISIN", "LATNAME", "REGNUMBER", "PREVLEGALCLOSEPRICE", "CURRENCYID", "SECTYPE", "LISTLEVEL", "SETTLEDATE"],
        "data": [
                ["SBER", "TQBR", "Сбербанк", 270, 10, 3, "A", "Т+: Акции и ДР - безадрес.", 2, "Сбербанк России ПАО ао", null, "FNDT", "EQIN", null, 0.01, 269.96, "SUR", "2023-10-17", 21586948000, "RU0009029540", "Sberbank", "10301481B", 270.46, "SUR", "1", 1, "2023-10-19"]
        ]
},
"marketdata": {
        "columns": ["SECID", "BOARDID", "BID", "BIDDEPTH", "OFFER", "OFFERDEPTH", "SPREAD", "BIDDEPTHT", "OFFERDEPTHT", "OPEN", "LOW", "HIGH", "LAST", "LASTCHANGE", "LASTCHANGEPRCNT", "QTY", "VALUE", "VALUE_USD", "WAPRICE", "LASTCNGTOLASTWAPRICE", "WAPTOPREVWAPRICEPRCNT", "WAPTOPREVWAPRICE", "CLOSEPRICE", "MARKETPRICETODAY", "MARKETPRICE", "LASTTOPREVPRICE", "NUMTRADES", "VOLTODAY", "VALTODAY", "VALTODAY_USD", "ETFSETTLEPRICE", "TRADINGSTATUS", "UPDATETIME", "LASTBID", "LASTOFFER", "LCLOSEPRICE", "LCURRENTPRICE", "MARKETPRICE2", "NUMBIDS", "NUMOFFERS", "CHANGE", "TIME", "HIGHBID", "LOWOFFER", "PRICEMINUSPREVWAPRICE", "OPENPERIODPRICE", "SEQNUM", "SYSTIME", "CLOSINGAUCTIONPRICE", "CLOSINGAUCTIONVOLUME", "ISSUECAPITALIZATION", "ISSUECAPITALIZATION_UPDATETIME", "ETFSETTLECURRENCY", "VALTODAY_RUR", "TRADINGSESSION"],
        "data": [
                ["SBER", "TQBR", 266.79, null, 266.8, null, 0.01, 517050, 903799, 270, 266.11, 271.19, 266.79, -0.01, 0, 50, 133395.00, 1370.32, 268.98, -3.17, -0.36, -0.98, null, null, 269.93, -1.19, 70659, 28693620, 7717500748, 79279237, null, "T", "16:10:42", null, null, null, 267, null, null, null, -3.21, "16:10:42", null, null, -3.17, 270, 20231018162543, "2023-10-18 16:25:43", null, null, 5771702286760, "16:24:58", null, 7717500748, "1"]
        ]
},
"dataversion": {
        "columns": ["data_version", "seqnum"],
        "data": [
                [7925, 20231018162540]
        ]
},
"marketdata_yields": {
        "columns": ["boardid", "secid"],
        "data": [

        ]
}}
 
 */