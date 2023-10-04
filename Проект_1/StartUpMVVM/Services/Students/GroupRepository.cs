using StartUpMVVM.Models.Decanat;
using StartUpMVVM.Services.Base;

namespace StartUpMVVM.Services.Students;

class GroupRepository : RepositoryInMemory<Group> {
    
    public GroupRepository() : base(TestData.Groups) { }

    public Group? Get(string GroupName) => 
        GetAll().FirstOrDefault(g => g.Name == GroupName);

    protected override void Update(Group Source, Group Destination) {
        Destination.Name = Source.Name;
        Destination.Description = Source.Description;
    }
}
