using System.Security.Claims;
using System.Text;
using TaskManager.API.Models.Data;

namespace TaskManager.API.Models.Services;


public class UserService {
    private readonly ApplicationContext _db;

    public UserService(ApplicationContext db) => _db = db;

    public Tuple<string, string> GetUserLoginPassFromBasicAuth(HttpRequest request) {
        string userName = "";
        string userPass = "";
        string authHeader = request.Headers["Authorization"].ToString();

        if (authHeader != null && authHeader.StartsWith("Basic")) {
            string encodedUserNamePass = authHeader.Replace("Basic", "");

            var encoding = Encoding.GetEncoding("iso-8859-1");

            string[] namePassArray = encoding.GetString(
                Convert.FromBase64String(encodedUserNamePass))
                .Split(':');

            userName = namePassArray[0];
            userPass = namePassArray[1];
        }
        return Tuple.Create(userName, userPass);
    }

    public User? GetUser(string login, string pass) {
        var user = _db.Users.FirstOrDefault(u =>
            u.Email == login && u.Password == pass
        );
        return user;
    }

    public ClaimsIdentity? GetIdentity(string username, string password) {
        User? currentUser = GetUser(username, password);

        if (currentUser == null)
            return null;
        if (currentUser.Email is null)
            throw new ArgumentException("У пользователя нет email-адреса");

        currentUser.LastLoginDate = DateTime.Now;
        _db.Users.Update(currentUser);
        _db.SaveChanges();

        var claims = new List<Claim> {
            new Claim(ClaimsIdentity.DefaultNameClaimType, currentUser.Email),
            new Claim(ClaimsIdentity.DefaultNameClaimType, currentUser.Status.ToString()),
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", 
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }
}
