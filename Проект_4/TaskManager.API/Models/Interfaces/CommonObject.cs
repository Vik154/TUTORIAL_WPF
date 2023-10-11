namespace TaskManager.API.Models.Interfaces;

public abstract class CommonObject {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }
    public byte[]? Photo { get; set; }
}
