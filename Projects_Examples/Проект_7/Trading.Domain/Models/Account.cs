namespace Trading.Domain.Models;

public class Account { 
    /// <summary> Идентификатор аккаунта </summary>
    public int Id { get; set; }

    /// <summary> Владелец аккаунта </summary>
    public User AccountHolder { get; set; }

    /// <summary> Баланс </summary>
    public double Balance { get; set; }

    /// <summary> Операции с активами </summary>
    public IEnumerable<AssertTransaction> AssertTransactions { get; set; }
}