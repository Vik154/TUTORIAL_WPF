namespace Trading.Domain.Models;

public class Account : DomainObject { 

    /// <summary> Владелец аккаунта </summary>
    public User? AccountHolder { get; set; }

    /// <summary> Баланс </summary>
    public double Balance { get; set; }

    /// <summary> Операции с активами </summary>
    public ICollection<AssetTransaction> AssetTransactions { get; set; }
}