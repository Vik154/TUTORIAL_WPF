using System.Numerics;
using TaskManager.Common.Models;

namespace TaskManager.API.Models;

public class User {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public byte[]? Photo { get; set; }
    public List<Project> Projects { get; set; } = new();
    public List<Desk> Desks { get; set; } = new();
    public List<TaskModel> Tasks { get; set; } = new();
    public UserStatus Status { get; set; }

    public User() { }

    public User(string fname, string lname, string email, string password,
                UserStatus userstatus = UserStatus.User, 
                string? phone = null, byte[]? photo = null) 
    {
        FirstName = fname;
        LastName = lname;
        Email = email;
        Password = password;
        Status = userstatus;
        Phone = phone;
        Photo = photo;
        RegistrationDate = DateTime.Now;
    }

    public UserModel ToDto() {
        return new UserModel {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password,
            Status = Status,
            Phone = Phone,
            Photo = Photo,
            RegistrationDate = RegistrationDate
        };
    }
}
