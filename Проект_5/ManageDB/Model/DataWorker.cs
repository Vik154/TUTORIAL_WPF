using ManageDB.Model.Data;

namespace ManageDB.Model;

// Класс для взаимодействия с базой данных
internal static class DataWorker {

    /// <summary> Вернуть отдел </summary>
    public static List<Department> GetAllDepartments() {
        using (ApplicationContext db = new ApplicationContext()) {
            return db.Departments.ToList();
        }
    }

    /// <summary> Вернуть сотрудника </summary>
    public static List<User> GetAllUsers() {
        using (ApplicationContext db = new ApplicationContext()) {
            return db.Users.ToList();
        }
    }

    /// <summary> Вернуть позицию </summary>
    public static List<Position> GetAllPosition() {
        using (ApplicationContext db = new ApplicationContext()) {
            return db.Positions.ToList();
        }
    }

    /// <summary> Создать отдел </summary>
    public static string CreateDepartment(string name) {
        string result = "Уже существует";

        using (ApplicationContext db = new ApplicationContext()) {
            
            // Проверяет - существует ли отдел
            bool checkIsExist = db.Departments.Any(x => x.Name == name);

            if (!checkIsExist) {
                Department newDepartment = new Department { Name = name};
                db.Departments.Add(newDepartment);
                db.SaveChanges();
                result = "Выполнено";
            }
            return result;
        }
    }

    /// <summary> Создать позицию </summary>
    public static string CreatePosition(string name, decimal salary,
        int maxNumber, Department department) 
    {
        string result = "Уже существует";

        using (ApplicationContext db = new ApplicationContext()) {
            
            // Проверяет существует ли позиция
            bool checkIsExist = db.Positions
                .Any(x => x.Name == name && x.Salary == salary);

            if (!checkIsExist) {
                Position newPosition = new Position { 
                    Name = name,
                    Salary = salary,
                    MaxNumber = maxNumber,
                    DepartmentId = department.Id
                };
                db.Positions.Add(newPosition);
                db.SaveChanges();
                result = "Выполнено";
            }
            return result;
        }
    }

    /// <summary> Создать сотрудника </summary>
    public static string CreateUser(string name, string surName, 
                                    string phone, Position position) 
    {
        string result = "Уже существует";

        using (ApplicationContext db = new ApplicationContext()) {

            // Проверяет существует ли позиция
            bool checkIsExist = db.Users.Any(x => 
                x.Name == name && 
                x.SurName == surName &&
                x.Position == position);

            if (!checkIsExist) {
                User newUser = new User {
                    Name = name,
                    SurName = surName,
                    Phone = phone,
                    PositionId = position.Id
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                result = "Выполнено";
            }
            return result;
        }
    }

    /// <summary> Удалить отдел </summary>
    public static string DeleteDepartment(Department department) {
        string result = "Отдела не существует";

        using (ApplicationContext db = new ApplicationContext()) {
            db.Departments.Remove(department);
            db.SaveChanges();
            result = $"Отдел {department.Name} удален";
        }
        return result;
    }

    /// <summary> Удалить сотрудника </summary>
    public static string DeleteUser(User user) {
        string result = "Сотрудника не существует";

        using (ApplicationContext db = new ApplicationContext()) {
            db.Users.Remove(user);
            db.SaveChanges();
            result = $"Сотрудник {user.Name} удален";
        }
        return result;
    }

    /// <summary> Удалить позицию </summary>
    public static string DeletePosition(Position position) {
        string result = "Позиции не существует";

        using (ApplicationContext db = new ApplicationContext()) {
            db.Positions.Remove(position);
            db.SaveChanges();
            result = $"Позиция {position.Name} удалена";
        }
        return result;
    }

    /// <summary> Редактировать отдел </summary>
    public static string EditDepartment(Department oldDepartment, string newName) {
        string result = "Отдела не существует";

        using (ApplicationContext db = new ApplicationContext()) {
            Department? department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
            
            if (department == null)
                return result;
            
            department.Name = newName;
            db.SaveChanges();
            result = $"Отдел {department.Name} изменен";
        }
        return result;
    }

    /// <summary> Редактировать позицию </summary>
    public static string EditPosition(Position oldPosition, string newName,
        int newMaxNumber, decimal newSalary, Department newDepartment) 
    {
        string result = "Позиции не существует";

        using (ApplicationContext db = new ApplicationContext()) {
            Position? position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);

            if (position == null)
                return result;

            position.Name = newName;
            position.Salary = newSalary;
            position.MaxNumber = newMaxNumber;
            position.DepartmentId = newDepartment.Id;
            db.SaveChanges();
            result = $"Позиция {oldPosition.Name} отредактирована";
        }
        return result;
    }

    /// <summary> Редактировать сотрудника </summary>
    public static string EditUser(User oldUser, string newName,
        string newSurName, string newPhone, Position newPosition) 
    {
        string result = "Сотрудника не существует";

        using (ApplicationContext db = new ApplicationContext()) {
            User? user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);

            if (user == null)
                return result;

            user.Name = newName;
            user.SurName = newSurName;
            user.Phone = newPhone;
            user.PositionId = newPosition.Id;
            db.SaveChanges();
            result = $"Сотрудник {oldUser.Name} отредактирован";
        }
        return result;
    }
}
