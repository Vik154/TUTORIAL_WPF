using TaskManager.Common.Models;

namespace TaskManager.API.Models.Interfaces;

public abstract class CommonObject {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public byte[]? Photo { get; set; }

    public CommonObject() {
        CreationDate = DateTime.Now;
    }

    public CommonObject(CommonModel model) {
        Name = model.Name;
        Description = model.Description;
        CreationDate = DateTime.Now;
        Photo = model.Photo;
    }
}
