﻿namespace Trading.Domain.Exceptions;

/// <summary> Некорректный тикер акций </summary>
public class InvalidSymbolException : Exception {
    public string Symbol { get; set; }

    public InvalidSymbolException(string symbol) => Symbol = symbol;
    public InvalidSymbolException(string symbol, string message) : base(message) => Symbol = symbol;
    public InvalidSymbolException(string symbol, string message, Exception innerException) 
        : base(message, innerException) => Symbol = symbol;
}
