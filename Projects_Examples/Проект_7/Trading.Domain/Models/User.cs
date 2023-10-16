namespace Trading.Domain.Models;

/// <summary> Класс представляющий пользователя </summary>
public class User {
    /// <summary> ID пользователя в БД </summary>
    public int Id { get; set; }

    /// <summary> Почта </summary>
    public string? Email {  get; set; }

    /// <summary> Имя пользователя </summary>
    public string? Username {  get; set; }

    /// <summary> Пароль </summary>
    public string? Password { get; set; }

    /// <summary> Дата подключения </summary>
    public DateTime DateJoined { get; set; }
}
