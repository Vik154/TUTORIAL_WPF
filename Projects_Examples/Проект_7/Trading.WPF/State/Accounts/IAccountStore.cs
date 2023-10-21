using Trading.Domain.Models;

namespace Trading.WPF.State.Accounts;

public interface IAccountStore {
    Account CurrentAccount { get; set; }
    event Action StateChanged;
}
