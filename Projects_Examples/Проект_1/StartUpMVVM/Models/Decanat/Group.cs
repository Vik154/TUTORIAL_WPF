using StartUpMVVM.Models.Interfaces;

namespace StartUpMVVM.Models.Decanat;

internal class Group : IEntity {
    public int Id { get; set; }
    public string? Name { get; set; }
    public IList<Student>? Students { get; set; } = new List<Student>();
    public string? Description { get; set; }
}
