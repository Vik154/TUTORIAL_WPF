using TaskManager.Common.Models;

namespace TaskManager.API.Models.Interfaces;

public abstract class CommonObject {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public byte[]? Photo { get; set; }

    public CommonObject() {
        CreatedDate = DateTime.MinValue;
    }

    public CommonObject(CommonModel model) {
        Name = model.Name;
        Description = model.Description;
        CreatedDate = model.CreatedDate;
        Photo = model.Photo;
    }
}
