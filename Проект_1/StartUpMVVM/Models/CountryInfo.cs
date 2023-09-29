namespace StartUpMVVM.Models;

// Информация по стране
internal class CountryInfo : PlaceInfo {
    public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
}
