using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace _07_Commands;

public partial class MainWindow : Window {

    // Указывает изменился ли документ с момента открытия
    // Флаг - Для работы со стандартными командами
    // private bool isDirty = false;
    
    public MainWindow() {
        InitializeComponent();

        #region Стандартные команды WPF
        //CommandBinding commandBinding = new CommandBinding(ApplicationCommands.New);
        //commandBinding.Executed += NewCommand;
        //this.CommandBindings.Add(commandBinding);

        //commandBinding = new CommandBinding(ApplicationCommands.Open);
        //commandBinding.Executed += OpenCommand;
        //this.CommandBindings.Add(commandBinding);

        //commandBinding = new CommandBinding(ApplicationCommands.Save);
        //commandBinding.Executed += SaveCommand_Executed;
        //commandBinding.CanExecute += SaveCommand_CanExecute;
        //this.CommandBindings.Add(commandBinding);
        #endregion

        #region Первый пример
        //CommandBinding commandBinding = new CommandBinding(ApplicationCommands.Help);
        //commandBinding.Executed += new ExecutedRoutedEventHandler(MyLogical);
        //btn.CommandBindings.Add(commandBinding);
        #endregion
    }

    #region MyCoomand
    //private void Edit_Executed(object sender, ExecutedRoutedEventArgs e) {
    //    txt.IsReadOnly = false;
    //}

    //private void Delete_Executed(object sender, ExecutedRoutedEventArgs e) {
    //    txt.Clear();
    //}
    #endregion

    #region Стандартные команды WPF
    //private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
    //    e.CanExecute = isDirty;
    //}

    //private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e) {
    //    MessageBox.Show($"Команда запущена с помощью {e.Source}");
    //    isDirty = false;
    //}

    //private void OpenCommand(object sender, ExecutedRoutedEventArgs e) {
    //    isDirty = false;
    //}

    //private void NewCommand(object sender, ExecutedRoutedEventArgs e) {
    //    MessageBox.Show($"Команда запущена с помощью {e.Source}");
    //    isDirty = false;
    //}

    //private void txt_TextChanged(object sender, TextChangedEventArgs e) {
    //    isDirty = true;
    //}
    #endregion

    #region Первый пример
    //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
    //    MessageBox.Show("Обработчик создан декларативно в XAML");
    //}

    // Обработчик для команды
    //private void MyLogical(object sender, ExecutedRoutedEventArgs e) {
    //    txtInfo.Text += $"Вызвана команда HELP\nИсточник: {e.Source}\n";
    //}
    #endregion

    #region Создание команд с помощью ICommand

    // Происходит при загрузке окна
    private void Window_Loaded(object sender, RoutedEventArgs e) {
        // К кнопке добавляется своя команда
        _button.Command = new CustomCommand(CommandExecute, CanCommandExecute);
    }

    private void CommandExecute(object param) {
        MessageBox.Show("Команда вызвана");
    }

    private bool CanCommandExecute(object param) {
        return _txt.Text != string.Empty;
    }
    #endregion
}
