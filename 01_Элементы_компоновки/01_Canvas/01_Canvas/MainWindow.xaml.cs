﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _01_Canvas;

public partial class MainWindow : Window {

    private List<Page> Pages { get; set; } = new List<Page>();

    public MainWindow() {
        InitializeComponent();
        Pages.Add(new _01_CanvasBase());
        Pages.Add(new _02_CanvasFromCode());
        
    }

    /// <summary> Отображает страницу 01_CanvasBase </summary>
    private void _01_Canvas_Click(object sender, RoutedEventArgs e) { 
        _frame.Content = Pages[0];
    }

    private void _02_Canvas_Click(object sender, RoutedEventArgs e) {
        _frame.Content = Pages[1];
    }
}
