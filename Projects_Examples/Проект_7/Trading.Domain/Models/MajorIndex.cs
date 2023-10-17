namespace Trading.Domain.Models;

/// <summary> Перечисление основных индексов </summary>
public enum MajorIndexType { RTS, MOEX }
// public enum MajorIndexType { DowJones, Nasdaq, SP500 }

/// <summary> Класс представляющий данные об индексе </summary>
public class MajorIndex {
    public string IndexName { get; set; } = "";
    public double Price { get; set; }
    public double Changes { get; set; }
    public MajorIndexType Type { get; set; }
}
