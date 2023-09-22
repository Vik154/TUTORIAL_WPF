using System.Windows;
using System.Windows.Controls;

namespace _06_Events;

public class MyButton : Button {

    // Создание и регистрация собственного события
    public static readonly RoutedEvent MyClickEvent =
                        EventManager.RegisterRoutedEvent(
                              "MyClick"
                            , RoutingStrategy.Bubble
                            , typeof(RoutedEventHandler)
                            , typeof(MyButton));
    
    // Обёртка над свойством CLR
    public event RoutedEventHandler MyClick {
        add { AddHandler(MyClickEvent, value); } 
        remove { RemoveHandler(MyClickEvent, value); } 
    }

    // Вызывает событие MyClick
    private void RaiseMyClickEvent() {
        RoutedEventArgs newEventArgs = new RoutedEventArgs(MyClickEvent);
        RaiseEvent(newEventArgs);
    }

    // Переопределение стандартного поведения
    protected override void OnClick() {
        RaiseMyClickEvent();
    }
}
