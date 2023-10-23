using ContactBook.Utility;

namespace ContactBook.Models;

/// <summary> Класс представляющий запись в телефонной книге </summary>
public class Contact : ObservableObject {

    /// <summary> Имя в телефонной книге </summary>
    private string? _name;

    /// <summary> Имя в телефонной книге </summary>
    public string? Name {
        get { return _name; }
        set { OnPropertyChanged(ref _name, value); }
    }

    /// <summary> Номер в телефонной книге </summary>
    private string[]? _phoneNumbers;

    /// <summary> Номер в телефонной книге </summary>
    public string[]? PhoneNumbers {
        get { return _phoneNumbers; }
        set { OnPropertyChanged(ref _phoneNumbers, value); }
    }

    /// <summary> Почта в телефонной книге </summary>
    private string[]? _emails;

    /// <summary> Почта в телефонной книге </summary>
    public string[]? Emails {
        get { return _emails; }
        set { OnPropertyChanged(ref _emails, value); }
    }

    /// <summary> Местоположение </summary>
    private string[]? _locations;

    /// <summary> Местоположение </summary>
    public string[]? Locations {
        get { return _locations; }
        set { OnPropertyChanged(ref _locations, value); }
    }

    /// <summary> Контакт принадлежит к группе Избранное </summary>
    private bool _isFavorite;

    /// <summary> Контакт принадлежит к группе Избранное </summary>
    public bool IsFavorite {
        get { return _isFavorite; }
        set { OnPropertyChanged(ref _isFavorite, value); }
    }

    /// <summary> Путь к изображению контакта </summary>
    private string? _imagePath;

    /// <summary> Путь к изображению контакта </summary>
    public string? ImagePath {
        get { return _imagePath; }
        set { OnPropertyChanged(ref _imagePath, value); }
    }
}
