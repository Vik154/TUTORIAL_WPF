using Microsoft.EntityFrameworkCore;
using Trading.Domain.Models;
using Trading.Domain.Services;
using Trading.EntityFramework.Services.Common;

namespace Trading.EntityFramework.Services;


/// <summary> Поиск учетных записей </summary>
public class AccountDataService : IAccountService {

    private readonly SimpleTraderDbContextFactory _contextFactory;
    private readonly NonQueryDataService<Account> _nonQueryDataService;

    public AccountDataService(SimpleTraderDbContextFactory contextFactory) {
        _contextFactory = contextFactory;
        _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
    }

    public async Task<Account> Create(Account entity) {
        return await _nonQueryDataService.Create(entity);
    }

    public async Task<bool> Delete(int id) {
        return await _nonQueryDataService.Delete(id);
    }

    public async Task<Account> Update(int id, Account entity) {
        return await _nonQueryDataService.Update(id, entity);
    }

    public async Task<Account> Get(int id) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            Account findEntity = await db.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync((e) => e.Id == id);
            return findEntity;
        }
    }

    public async Task<IEnumerable<Account>> GetAll() {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            IEnumerable<Account> entities = await db.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .ToListAsync();
            return entities;
        }
    }

    public async Task<Account> GetByUsername(string username) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {

            return await db.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
        }
    }

    public async Task<Account> GetByEmail(string email) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {

            return await db.Accounts
                .Include (a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
        }
    }
}
