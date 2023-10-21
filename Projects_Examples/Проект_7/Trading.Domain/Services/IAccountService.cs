using Trading.Domain.Models;

namespace Trading.Domain.Services;

public interface IAccountService : IDataService<Account> {
    Task<Account> GetByUsername(string username);
    Task<Account> GetByEmail(string email);
}
