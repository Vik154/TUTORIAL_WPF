using StartUpMVVM.Models.Decanat;
using StartUpMVVM.Services.Base;

namespace StartUpMVVM.Services;

class GroupRepository : RepositoryInMemory<Group> {

    protected override void Update(Group Source, Group Destination) {
        Destination.Name = Source.Name;
        Destination.Description = Source.Description;
    }
}
