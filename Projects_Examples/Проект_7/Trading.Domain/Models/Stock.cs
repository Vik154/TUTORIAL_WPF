namespace Trading.Domain.Models;

/// <summary> Класс представляющий акцию </summary>
public class Stock {
    /// <summary> Символ, представляющий акцию </summary>
    public string Symbol { get; set; }

    /// <summary> Цена акции </summary>
    public double PricePerShare {  get; set; }
}
