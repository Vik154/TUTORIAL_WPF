using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace _07_Commands;

public partial class MainWindow : Window {

    // Указывает изменился ли документ с момента открытия
    private bool isDirty = false;
    
    public MainWindow() {
        InitializeComponent();

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

        //CommandBinding commandBinding = new CommandBinding(ApplicationCommands.Help);
        //commandBinding.Executed += new ExecutedRoutedEventHandler(MyLogical);
        //btn.CommandBindings.Add(commandBinding);
    }


    private void Edit_Executed(object sender, ExecutedRoutedEventArgs e) {
        txt.IsReadOnly = false;
    }

    private void Delete_Executed(object sender, ExecutedRoutedEventArgs e) {
        txt.Clear();
    }



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




    //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
    //    MessageBox.Show("Обработчик создан декларативно в XAML");
    //}

    // Обработчик для команды
    //private void MyLogical(object sender, ExecutedRoutedEventArgs e) {
    //    txtInfo.Text += $"Вызвана команда HELP\nИсточник: {e.Source}\n";
    //}
}
