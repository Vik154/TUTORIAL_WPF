using StartUpMVVM.Models;

namespace StartUpMVVM.Services.Interfaces;

internal interface IDataService {
    IEnumerable<CountryInfo> GetData();
}
