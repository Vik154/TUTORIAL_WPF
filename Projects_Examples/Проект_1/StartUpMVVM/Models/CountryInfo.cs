using System.Windows;

namespace StartUpMVVM.Models;

// Информация по стране
internal class CountryInfo : PlaceInfo {
    private Point? _Location;

    public override Point Location { 
        get {
            if (_Location != null) 
                return (Point)_Location;
            
            if (Provinces is null)
                return default;

            var average_x = Provinces.Average(p => p.Location.X);
            var average_y = Provinces.Average(p => p.Location.Y);
            
            return (Point)(_Location = new Point(average_x, average_y));
        }

        set => _Location = value;
    }

    public IEnumerable<PlaceInfo>? Provinces { get; set; }

    private IEnumerable<ConfirmedCount>? _Counts;

    public override IEnumerable<ConfirmedCount>? Counts { 
        get {
            if (_Counts != null) 
                return _Counts;

            var points_count = Provinces?.FirstOrDefault()?.Counts?.Count();
            
            if (points_count == 0 || points_count is null) 
                return Enumerable.Empty<ConfirmedCount>();

            var province_points = Provinces?.Select(p => p.Counts?.ToArray()).ToArray();

            if (province_points is null ||  province_points.Length == 0)
                return Enumerable.Empty<ConfirmedCount>();

            var points = new ConfirmedCount[(int)points_count];

            foreach (var province in province_points)
                for (var i = 0; i < points_count; i++) {
                    if (points[i].Date == default)
                        points[i] = province![i];
                    else
                        points[i].Count += province![i].Count;
                }

            return _Counts = points;
        }

        set => base.Counts = value; 
    }
}
