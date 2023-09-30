using StartUpMVVM.Models;
using System.Windows;
using System.Globalization;
using System.Linq;

namespace MVVMConsole;


//internal class Program {

//    private const string data_uri = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

//    // Возвращает поток, из которого можно будет читать данные
//    private static async Task<Stream> GetDataStream() {
//        // Создание клиента
//        var client = new HttpClient();

//        // Получение ответа от сервера, который не скачивает сразу весь файл, а только заголовки,
//        // остальное тело запроса, пока что не требуется извлекать из буфера сетевой карты
//        var response = await client.GetAsync(data_uri, HttpCompletionOption.ResponseHeadersRead);

//        // Возвращает поток, который позволит читать из буфера сетевой карты
//        return await response.Content.ReadAsStreamAsync();
//    }

//    // Чтение данных из потока с разбиением на строки, т.е. 
//    // каждая строка извлекается отдельно из потока
//    private static IEnumerable<string> GetDataLines() {
//        using var data_stream = GetDataStream().Result;         // Получаем поток
//        using var data_reader = new StreamReader(data_stream);  // Читатель данных из потока

//        while (!data_reader.EndOfStream) {      // Чтение данных, пока не закончится поток
//            var line = data_reader.ReadLine();  // Построчное чтение из потока
//            if (string.IsNullOrEmpty(line))     // Если строка пустая, читаем дальше до конца потока
//                continue;
//            yield return line
//                .Replace("Korea,", "Korea -")
//                .Replace("Bonaire,", "Bonaire -");
//            // Прочитал 1 строчку - вернул, если больше не нужно читать,
//            // прервал чтение и остальные данные не загружают память.
//            // "Korea," на "Korea-" для корректного отображения данных при парсинге
//        }
//    }

//    // Выделение необходимых данных, полученных из потока
//    private static DateTime[] GetDates() => GetDataLines()  // Получаем перечисление строк запроса
//        .First()        // Выбираем первую
//        .Split(',')     // Разделение строки по ","
//        .Skip(4)        // Пропускаем первые 4 колонки
//        .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture)) // Преобразование строки в DateTime
//        .ToArray();     // Приведение данных к массиву


//    // Возвращает кортеж данных - страна, провинция, число зараженных
//    private static IEnumerable<(string Country, string Province, int[] Counts)> GetData() {
//        var lines = GetDataLines()
//            .Skip(1)
//            .Select(line => line.Split(','));

//        foreach (var row in lines) {
//            var province = row[0].Trim();
//            var country_name = row[1].Trim(' ', '"');
//            var counts = row.Skip(4).Select(int.Parse).ToArray();

//            yield return (country_name, province, counts);
//        }
//    }

//    static void Main(string[] args) {

//         var ru = GetData()
//            .First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));

//        Console.WriteLine(string.Join("\r\n", GetDates().Zip(ru.Counts, (date, counts) => $"{date} - {counts}")));
//    }
//}


internal static class DataService {
    private const string __DataSourceAddress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

    // Возвращает поток, из которого можно будет читать данные
    private static async Task<Stream> GetDataStream() {
        // Создание клиента
        var client = new HttpClient();

        // Получение ответа от сервера, который не скачивает сразу весь файл, а только заголовки,
        // остальное тело запроса, пока что не требуется извлекать из буфера сетевой карты
        var response = await client.GetAsync(
            __DataSourceAddress,
            HttpCompletionOption.ResponseHeadersRead);

        // Возвращает поток, который позволит читать из буфера сетевой карты
        return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
    }

    // Чтение данных из потока с разбиением на строки, т.е. 
    // каждая строка извлекается отдельно из потока
    private static IEnumerable<string> GetDataLines() {

        using var data_stream = (SynchronizationContext.Current is null ?
            GetDataStream() : Task.Run(GetDataStream)).Result;              // Получаем поток

        using var data_reader = new StreamReader(data_stream);  // Читатель данных из потока

        
        while (!data_reader.EndOfStream) {      // Чтение данных, пока не закончится поток
            var line = data_reader.ReadLine();  // Построчное чтение из потока
            if (string.IsNullOrEmpty(line))     // Если строка пустая, читаем дальше до конца потока
                continue;
            yield return line
                .Replace("Korea,", "Korea -")
                .Replace("Bonaire,", "Bonaire -")
                .Replace("Helena,", "Helena -");
            // Прочитал 1 строчку - вернул, если больше не нужно читать,
            // прервал чтение и остальные данные не загружают память.
            // "Korea," на "Korea-" для корректного отображения данных при парсинге
        }
        

        //while (!data_reader.EndOfStream) {      // Чтение данных, пока не закончится поток
        //    var line = data_reader.ReadLine();  // Построчное чтение из потока
        //    //if (string.IsNullOrEmpty(line))     // Если строка пустая, читаем дальше до конца потока
        //    //    continue;
        //    //yield return line;

        //    if (line.Contains('"'))
        //        line = line.Insert(line.IndexOf(',', line.IndexOf('"')) + 1, " -").Remove(line.IndexOf(',', line.IndexOf('"')), 1);
        //    yield return line;
        //}
    }

    // Выделение необходимых данных, полученных из потока
    private static DateTime[] GetDates() => GetDataLines()  // Получаем перечисление строк запроса
    .First()        // Выбираем первую
    .Split(',')     // Разделение строки по ","
    .Skip(4)        // Пропускаем первые 4 колонки
    .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture)) // Преобразование строки в DateTime
        .ToArray();     // Приведение данных к массиву

    // Возвращает кортеж данных - страна, провинция, число зараженных
    private static IEnumerable<(string Province,
                                string Country,
                                (double Lat, double Lot) Place,
                                int[] Counts)>
        GetCountriesData() {

        var lines = GetDataLines()
            .Skip(1)
            .Select(line => line.Split(','));

        foreach (var row in lines) {
            var province = row[0].Trim();
            var country_name = row[1].Trim(' ', '"');
            //var latitude = double.Parse(row[2]);
            //var longitude = double.Parse(row[3]);
            //var counts = row.Skip(4).Select(int.Parse).ToArray();

            var latitude = double.Parse(row[3] == "" ? "0" : row[3], CultureInfo.InvariantCulture);
            var longitude = double.Parse(row[4] == "" ? "0" : row[4], CultureInfo.InvariantCulture);
            var counts = row.Skip(5).Select(int.Parse).ToArray();

            yield return (province, country_name, (latitude, longitude), counts);
        }
    }

    public static IEnumerable<CountryInfo> GetData() {

        var dates = GetDates();
        var data = GetCountriesData().GroupBy(d => d.Country);

        foreach (var country_info in data) {

            var country = new CountryInfo {
                Name = country_info.Key,
                ProvinceCounts = country_info.Select(c => new PlaceInfo {
                    Name = c.Province,
                    Location = new Point(c.Place.Lat, c.Place.Lot),
                    Counts = dates.Zip(c.Counts, (date, count) => new ConfirmedCount {
                        Date = date,
                        Count = count
                    })
                })
            };
            yield return country;
        }
    }

    static void Main(string[] args) {

        var ru = GetData()
           .First(v => v.Name.Equals("Russia", StringComparison.OrdinalIgnoreCase));


        Console.WriteLine(ru.Name.First(i => i.Equals("Russia")));

        // Console.WriteLine(string.Join("\r\n", GetDates().Zip(ru.Counts, (date, counts) => $"{date} - {counts}")));
    }
}
