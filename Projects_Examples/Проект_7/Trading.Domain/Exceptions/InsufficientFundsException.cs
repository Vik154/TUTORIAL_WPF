namespace Trading.Domain.Exceptions;

/// <summary> Исключение при нехватке средств на счёте для покупки акций </summary>
public class InsufficientFundsException : Exception {

    public double AccountBalance { get; set; }
    public double RequiredBalance { get; set; }

    public InsufficientFundsException(double accountBalance, double requiredBalance) {
        AccountBalance = accountBalance;
        RequiredBalance = requiredBalance;
    }

    public InsufficientFundsException(double accountBalance, double requiredBalance, string message) : base(message) {
        AccountBalance = accountBalance;
        RequiredBalance = requiredBalance;
    }

    public InsufficientFundsException(double accountBalance, double requiredBalance, string message, Exception innerException) : base(message, innerException) {
        AccountBalance = accountBalance;
        RequiredBalance = requiredBalance;
    }
}
