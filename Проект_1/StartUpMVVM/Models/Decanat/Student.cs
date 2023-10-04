using StartUpMVVM.Models.Interfaces;

namespace StartUpMVVM.Models.Decanat;

internal class Student : IEntity {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? SurName {  get; set; }
    public string? Patronymic {  get; set; }
    public DateTime Birthday { get; set; }
    public double Rating {  get; set; }
    public string? Description { get; set; }
}
