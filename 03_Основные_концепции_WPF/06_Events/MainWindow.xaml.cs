using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _06_Events;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void newButton_MyClick(object sender, RoutedEventArgs e) {
        MessageBox.Show($"Событие произошло: {e.Source}");
    }

    //#region События Мыши

    //int counter = 0;

    //private void ButtonClear_Click(object sender, RoutedEventArgs e) {
    //    txtBlockInfo.Text = string.Empty;
    //}

    //private void testEvent_MouseDown(object sender, MouseButtonEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: MouseDown - Поднимающееся\n" +
    //        $"Нажата кнопка мыши: {e.ChangedButton}; Кол-во нажатий: {e.ClickCount}\n";
    //}

    //private void testEvent_MouseEnter(object sender, MouseEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - Прямое\n" +
    //        $"Курсор попал в поле элемента \n";

    //}

    //private void testEvent_MouseLeave(object sender, MouseEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - Прямое\n" +
    //        $"Курсор вышел за пределы элемента\n"; 

    //}

    //private void testEvent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - Поднимающееся\n" +
    //        $"Нажата левая кнопка мыши\n";
    //}

    //private void testEvent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - Поднимающееся\n" +
    //        $"Отпущена левая кнопка мыши\n";
    //}

    //private void testEvent_MouseMove(object sender, MouseEventArgs e) {
    //    labelCoord.Content = $"X: {e.GetPosition(this).X}; Y: {e.GetPosition(this).Y}";
    //}

    //private void testEvent_MouseUp(object sender, MouseButtonEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - " +
    //        $"Поднимающееся\n Кнопка мыши отпущена\n";
    //}

    //private void testEvent_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - " +
    //        $"Прямое\n Кнопка мыши нажата\n";
    //}

    //private void testEvent_PreviewMouseUp(object sender, MouseButtonEventArgs e) {
    //    txtBlockInfo.Text += $"\n{++counter} Событие: {e.RoutedEvent.Name} - " +
    //        $"Прямое\n Кнопка мыши отпущена\n";
    //}

    //#endregion

    #region События клавиатуры
    //private void textBox_KeyEvent(object sender, KeyEventArgs e) {

    //    // Игнорировать повторные события
    //    if ((bool)checkIgnoreRepeat.IsChecked! && e.IsRepeat)
    //        return;

    //    // Запретить действие в TextBox некоторых клавиш
    //    if (checkIgnoreOther.IsChecked!.Value)
    //        switch (e.Key) {
    //            case Key.Space: // Пробел
    //            case Key.Left:  // Стрелка влево
    //            case Key.Right: // Стрелка вправо
    //            case Key.Home:  // В начало поля
    //            case Key.End:   // В конец поля
    //                e.Handled = true;
    //                break;
    //        }

    //    string key = e.Key.ToString();

    //    // Конвертируем вывод цифровых клавиш основной клавиатуры
    //    if (checkConvertNumber.IsChecked!.Value) {
    //        KeyConverter converter = new KeyConverter();
    //        key = converter.ConvertToString(e.Key)!;
    //    }

    //    string message = e.RoutedEvent.ToString();
    //    message = message.Substring(message.IndexOf('.') + 1);
    //    message = $"Event: {message, -30} \tKey: {key}\n";

    //    txtBlockInfo.Text += message;
    //}

    //private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
    //    if (checkIgnorePreviewTextInput.IsChecked!.Value)
    //        return;

    //    // Запрещаем в TextBox нечисловые символы 
    //    short val;

    //    // Попытка преобразовать в число без генерации исключения
    //    bool success = Int16.TryParse(e.Text, out val);
    //    if (!success) {
    //        e.Handled = true;   // Останавливаем событие
    //    }

    //    string message = e.RoutedEvent.ToString();
    //    message = message.Substring(message.IndexOf('.') + 1);
    //    message = $"Event: {message,-30} \tText: {e.Text}\n";

    //    txtBlockInfo.Text += message;
    //}

    //private void ClearButton_Click(object sender, RoutedEventArgs e) {
    //    txtBlockInfo.Text = string.Empty;
    //    txtBox.Clear();
    //}

    //private void Check_Click(object sender, RoutedEventArgs e) {

    //    // Распознаем и синхронизируем взаимосвязанные CheckBox
    //    FrameworkElement? checkBox = e.Source as FrameworkElement;
    //    switch (checkBox?.Name) {
    //        case "checkIgnoreSymbol":
    //            if (checkIgnoreSymbol.IsChecked!.Value)
    //                checkIgnorePreviewTextInput.IsChecked = false;
    //            break;
    //        case "checkIgnorePreviewTextInput":
    //            if (checkIgnorePreviewTextInput.IsChecked!.Value)
    //                checkIgnoreSymbol.IsChecked = false;
    //            break;
    //    }
    //}
    #endregion

    //int i = 0;

    //private void Bubble_MouseUp(object sender, MouseButtonEventArgs e) {
    //    textBlockInfo.Text += new string('*', 50) + $"\nОбъект: {sender} \n" +
    //        $"Источник: {e.Source} \nНачальный источник: {e.OriginalSource}\n";
    //}

    //private void Tunnel_MouseUp(object sender, MouseButtonEventArgs e) {
    //    ++i;
    //    textBlockInfo.Text += new string('*', 50) + $"\n{i}. \nОбъект: {sender} \n" +
    //        $"Источник: {e.Source} \nНачальный источник: {e.OriginalSource}\n";
    //}
}
