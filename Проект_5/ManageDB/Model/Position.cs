using System.ComponentModel.DataAnnotations.Schema;

namespace ManageDB.Model;

internal class Position {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Salary { get; set; }
    public int MaxNumber { get; set; }
    public List<User> Users { get; set; } = new();
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; } = new();

    [NotMapped]
    public Department? PositionDepartment {
        get => DataWorker.GetDepartmentById(DepartmentId);
    }
}
