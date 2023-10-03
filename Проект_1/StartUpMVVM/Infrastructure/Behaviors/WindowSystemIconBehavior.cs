using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using StartUpMVVM.Infrastructure.Extensions;

namespace StartUpMVVM.Infrastructure.Behaviors;

class WindowSystemIconBehavior : Behavior<Image> {
    protected override void OnAttached() {
        AssociatedObject.MouseLeftButtonDown += OnMouseDown;
    }

    protected override void OnDetaching() {
        AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
    }

    private void OnMouseDown(object Sender, MouseButtonEventArgs E) {
        if (!(AssociatedObject.FindVisualRoot() is Window window)) return;

        E.Handled = true;

        if (E.ClickCount > 1)
            window.Close();
        else
            window.SendMessage(WM.SYSCOMMAND, SC.KEYMENU);
    }
}
