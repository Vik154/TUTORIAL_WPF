using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using TaskManager.API.Models.Data;
using TaskManager.API.Models.Interfaces;
using TaskManager.Common.Models;

namespace TaskManager.API.Models.Services;


public class UserService : AbstractionService ,ICommonService<UserModel> {
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
    
    public User? GetUser(string login) {
        return _db.Users.FirstOrDefault(u => u.Email == login);
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

    public bool Create(UserModel model) {
        try {
            if (model is null) throw new ArgumentException("model not found");

            User newUser = new User(
                model.FirstName ??= "UnknownFirstName",
                model.LastName  ??= "UnknownLastName",
                model.Email     ??= "UnknownEmail",
                model.Password  ??= "UnknownPassword",
                model.Status, 
                model.Phone, 
                model.Photo);

            _db.Users.Add(newUser);
            _db.SaveChanges();
            return true;
        }
        catch (Exception) {
            // TODO
            return false;
        }
    }

    public bool Update(int id, UserModel model) {
        return DoAction(delegate () {
            if (model is null)
                throw new ArgumentException("Model not found");

            User? userUpdate = _db.Users.FirstOrDefault(x => x.Id == id);

            if (userUpdate is null)
                throw new ArgumentNullException(nameof(userUpdate));

            userUpdate.FirstName = model.FirstName;
            userUpdate.LastName = model.LastName;
            userUpdate.Password = model.Password;
            userUpdate.Phone = model.Phone;
            userUpdate.Photo = model.Photo;
            userUpdate.Status = model.Status;
            userUpdate.Email = model.Email;

            _db.Users.Update(userUpdate);
            _db.SaveChanges();
        });
    }

    public bool Delete(int id) {
        return DoAction(delegate () {
            User? user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
                throw new ArgumentNullException("User id not found");
            _db.Users.Remove(user);
            _db.SaveChanges();
        });
    }

    public bool CreateMultipleUsers(List<UserModel> userModels) {
        return DoAction(delegate () {
            if (userModels is null)
                throw new ArgumentNullException("UserModel not found");
            var newUsers = userModels.Select(u => new User(u));
            _db.Users.AddRange(newUsers);
            _db.SaveChangesAsync();
        });
    }

    //private bool DoAction(Action action) {
    //    try {
    //        action.Invoke();
    //        return true;
    //    }
    //    catch (Exception exp) {
    //        Debug.WriteLine(exp.Message);
    //        return false;
    //    }
    //}

}
