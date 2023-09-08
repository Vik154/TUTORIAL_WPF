using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _03_WrapPanel;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MakeWrapPanel();
    }

    /* Программное создание WrapPanel*/
    private void MakeWrapPanel() {
        WrapPanel wrapPanel = new WrapPanel {               // Создание объекта WrapPanel
            VerticalAlignment = VerticalAlignment.Top,      // Задает вертикальное выравнивание
            HorizontalAlignment = HorizontalAlignment.Left, // Задает горизонтальное выравнивание
            Orientation = Orientation.Horizontal,           // Размещение элементов внутри контейнера
            Background = Brushes.AliceBlue                  // Цвет фона
        };

        for (int i = 0; i < 20; ++i) {                      // Добавление нопок
            wrapPanel.Children.Add(new Button {             // Создание кнопки
                Content = $"Кнопка {i + 1}",                // Надпись на кнопке
                Height = new Random().Next(20, 100),        // Высота
                Width = new Random().Next(50, 150),         // Ширина
                FontWeight = FontWeights.Bold,              // Жирный шрифт
                Margin = new Thickness(5, 5, 0, 0),         // Внешние отступы left,top,r,b

                // Рандомная генерация цвета кнопки
                Background = new SolidColorBrush(Color.FromRgb(
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255)
                    ))
            });
        };

        this.Content = wrapPanel;
    }
}
