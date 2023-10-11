namespace TaskManager.Common.Models;


public class UserModel {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public byte[]? Photo { get; set; }
    public UserStatus Status { get; set; }

    public UserModel() { }

    public UserModel(string fname, string lname, string email, string password,
                    UserStatus userstatus, string phone)
    {
        FirstName = fname;
        LastName = lname;
        Email = email;
        Password = password;
        Status = userstatus;
        Phone = phone;
        RegistrationDate = DateTime.Now;
    }
}
