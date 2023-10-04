using StartUpMVVM.Models.Decanat;
using StartUpMVVM.Services.Base;

namespace StartUpMVVM.Services.Students;

class StudentsRepository : RepositoryInMemory<Student> {

    protected override void Update(Student Source, Student Destination) {
        Destination.Name = Source.Name;
        Destination.SurName = Source.SurName;
        Destination.Patronymic = Source.Patronymic;
        Destination.Birthday = Source.Birthday;
        Destination.Rating = Source.Rating;
    }
}
