﻿using StartUpMVVM.Models.Decanat;
using StartUpMVVM.Services.Interfaces;
using StartUpMVVM.Views.Windows;
using System.Windows;

namespace StartUpMVVM.Services;

class WindowsUserDialogService : IUserDialogService {

    private static Window ActiveWindow => 
        Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

    public bool Edit(object item) {
        if (item is null) throw new ArgumentNullException(nameof(item));

        switch (item) {
            default: throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
            case Student student:
                return EditStudent(student);
        }
    }

    public void ShowInformation(string Information, string Caption) => 
        MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

    public void ShowWarning(string Message, string Caption) => 
        MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

    public void ShowError(string Message, string Caption) => 
        MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

    public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
        MessageBox.Show(
            Message,
            Caption,
            MessageBoxButton.YesNo,
            Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
        == MessageBoxResult.Yes;

    public string GetStringValue(string Message, string Caption, string DefaultValue = null) {
        var value_dialog = new StringValueDialogWindow {
            Message = Message,
            Title = Caption,
            Value = DefaultValue ?? string.Empty,
            Owner = ActiveWindow
        };

        return value_dialog.ShowDialog() == true ? value_dialog.Value : DefaultValue;
    }

    private static bool EditStudent(Student student) {
        var dlg = new StudentEditorWindow {
            FirstName = student.Name,
            LastName = student.SurName,
            Patronymic = student.Patronymic,
            Rating = student.Rating,
            Birthday = student.Birthday,
            Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() != true) 
            return false;

        student.Name = dlg.FirstName;
        student.SurName = dlg.LastName;
        student.Patronymic = dlg.Patronymic;
        student.Rating = dlg.Rating ??= 0;
        student.Birthday = dlg.Birthday ??= DateTime.Now;

        return true;
    }
}
