namespace Trading.Domain.Models;

/// <summary> Класс представляющий сделки с активами </summary>
public class AssertTransaction {

    /// <summary> Идентификатор транзакции </summary>
    public int Id { get; set; }

    /// <summary> Аккаунт связанный с транзакцией </summary>
    public Account Account { get; set; }

    /// <summary> Флаг указывающий на тип транзакции buy / sell </summary>
    public bool IsPurchase { get; set; }

    /// <summary> Акция связанная с транзакцией </summary>
    public Stock Stock { get; set; }

    /// <summary> Количество акций </summary>
    public int Shares { get; set; }
}
