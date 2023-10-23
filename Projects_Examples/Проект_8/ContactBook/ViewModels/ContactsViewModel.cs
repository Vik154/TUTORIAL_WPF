using ContactBook.Models;
using ContactBook.Services;
using ContactBook.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContactBook.ViewModels;

/// <summary> Модель - представление хранящая все существующие контакты в записной книге </summary>
public class ContactsViewModel : ObservableObject {

    #region СВОЙСТВА

    /// <summary> Выбранный контакт из списка контактов </summary>
    private Contact? _selectedContact;

    /// <summary> Выбранный контакт из списка контактов </summary>
    public Contact? SelectedContact {
        get => _selectedContact;
        set => OnPropertyChanged(ref _selectedContact, value);
    }

    /// <summary> Список контактов </summary>
    public ObservableCollection<Contact> Contacts { get; set; }

    /// <summary> Флаг для включения режима редактирования </summary>
    private bool _isEditMode;

    /// <summary> Флаг для включения режима редактирования </summary>
    public bool IsEditMode {
        get => _isEditMode;
        set {
            OnPropertyChanged(ref _isEditMode, value);
            OnPropertyChanged("IsDisplayMode");
        }
    }

    /// <summary> Флаг для включения режима просмотра </summary>
    public bool IsDisplayMode => !_isEditMode;

    #endregion

    #region КОМАНДЫ
    public ICommand EditCommand { get; private set; }
    public ICommand SaveCommand { get; private set; }
    public ICommand UpdateCommand { get; private set; }
    public ICommand BrowseImageCommand { get; private set; }
    public ICommand AddCommand { get; private set; }
    public ICommand DeleteCommand { get; private set; }
    #endregion

    private IContactDataService _dataService;
    // private IDialogService _dialogService;

    public ContactsViewModel(IContactDataService dataService /*IDialogService dialogService*/) {
        _dataService = dataService;
        // _dialogService = dialogService;

        EditCommand = new RelayCommand(Edit, CanEdit);
        SaveCommand = new RelayCommand(Save, IsEdit);
        UpdateCommand = new RelayCommand(Update);
        // BrowseImageCommand = new RelayCommand(BrowseImage, IsEdit);
        AddCommand = new RelayCommand(Add);
        DeleteCommand = new RelayCommand(Delete, CanDelete);
    }

    #region МЕТОДЫ
    /// <summary> Загрузка списка контактов </summary>
    public void LoadContacts(IEnumerable<Contact> contacts) {
        Contacts = new ObservableCollection<Contact>(contacts);
        OnPropertyChanged("Contacts");
    }

    private void Delete() {
        Contacts.Remove(SelectedContact);
        Save();
    }

    private bool CanDelete() {
        return SelectedContact == null ? false : true;
    }

    private void Add() {
        var newContact = new Contact {
            Name = "N/A",
            PhoneNumbers = new string[2],
            Emails = new string[2],
            Locations = new string[2]
        };

        Contacts.Add(newContact);
        SelectedContact = newContact;
    }

    //private void BrowseImage() {
    //    var filePath = _dialogService.OpenFile("Image files|*.bmp;*.jpg;*.jpeg;*.png|All files");
    //    SelectedContact.ImagePath = filePath;
    //}

    private void Update() {
        _dataService.Save(Contacts);
    }

    private void Save() {
        _dataService.Save(Contacts);
        IsEditMode = false;
        OnPropertyChanged("SelectedContact");
    }

    private bool IsEdit() {
        return IsEditMode;
    }

    private bool CanEdit() {
        if (SelectedContact == null)
            return false;

        return !IsEditMode;
    }

    private void Edit() {
        IsEditMode = true;
    }
    #endregion
}
