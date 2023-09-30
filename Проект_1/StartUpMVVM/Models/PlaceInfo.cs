using System.Windows;

namespace StartUpMVVM.Models;

internal class PlaceInfo {
    public string? Name { get; set; }
    public virtual Point Location { get; set; }

    // Кол-во подтвержденных случаев
    public virtual IEnumerable<ConfirmedCount>? Counts { get; set; }

    public override string ToString() => $"{Name}({Location})";
}
