using System.Windows;

namespace StartUpMVVM.Models;

internal class PlaceInfo {
    public string Name { get; set; }
    public Point Location { get; set; }

    // Кол-во подтвержденных случаев
    public IEnumerable<ConfirmedCount> Counts { get; set; }
}
