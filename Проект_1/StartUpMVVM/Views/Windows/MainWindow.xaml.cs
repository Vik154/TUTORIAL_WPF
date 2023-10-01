using StartUpMVVM.Models.Decanat;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace StartUpMVVM;


 public partial class MainWindow : Window {

    public MainWindow() => InitializeComponent();

    private void GroupsCollectionFilter(object sender, FilterEventArgs e) {
        if(!(e.Item is Group group)) 
            return;
        if (group.Name is null)
            return;

        var filter_text = GroupNameFilterText.Text;
        if (filter_text.Length == 0) return;
    
        if (group.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;
        if (group.Description != null && group.Description.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

        e.Accepted = false;
    }

    private void OnGroupsFilterChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
        var text_box = (TextBox)sender;
        var collection = (CollectionViewSource)text_box.FindResource("GroupsCollection");
        collection.View.Refresh();
    }
}