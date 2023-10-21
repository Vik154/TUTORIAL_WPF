using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Trading.WPF.Views;

public partial class SellView : UserControl {
    public static readonly DependencyProperty SelectedAssetChangedCommandProperty =
        DependencyProperty.Register("SelectedAssetChangedCommand", typeof(ICommand), typeof(SellView),
            new PropertyMetadata(null));

    public ICommand SelectedAssetChangedCommand {
        get { return (ICommand)GetValue(SelectedAssetChangedCommandProperty); }
        set { SetValue(SelectedAssetChangedCommandProperty, value); }
    }

    public SellView() {
        InitializeComponent();
    }

    private void cbAssets_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        if (cbAssets.SelectedItem != null) {
            if (SelectedAssetChangedCommand.CanExecute(null)) {
                SelectedAssetChangedCommand?.Execute(null);
            }
        }
    }
}
