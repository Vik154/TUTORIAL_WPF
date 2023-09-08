using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _04_DockPanel;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MakeDockPanel();
    }

    /* Программное создание DockPanel*/
    private void MakeDockPanel() {
        DockPanel dockPanel = new DockPanel {               // Создание контейнера
            VerticalAlignment = VerticalAlignment.Top,      // Задает вертикальное выравнивание
            HorizontalAlignment = HorizontalAlignment.Left, // Задает горизонтальное выравнивание
            Background = Brushes.AliceBlue                  // Цвет фона
        };

        for (int i = 0; i < 20; ++i) {                      // Добавление нопок
            Button btn = new Button {                       // Создание кнопки
                Content = $"Кнопка {i + 1}",                // Надпись на кнопке
                FontWeight = FontWeights.Bold,              // Жирный шрифт
                Margin = new Thickness(5, 5, 0, 0),         // Внешние отступы left,top,r,b

                // Рандомная генерация цвета кнопки
                Background = new SolidColorBrush(Color.FromRgb(
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255)
                    ))
            };

            dockPanel.Children.Add(btn);            // Добавление в родительский контейнер
            DockPanel.SetDock(btn, (Dock)(i % 4));  // Выбор положения (Doc.Top/Right/Left..)
        
        }; // for

        this.Content = dockPanel;
    
    } // method MakeDockPanel()

} // class MainWindow
