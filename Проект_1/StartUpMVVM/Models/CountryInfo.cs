namespace StartUpMVVM.Models;

// Информация по стране
internal class CountryInfo : PlaceInfo {
    public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
}
