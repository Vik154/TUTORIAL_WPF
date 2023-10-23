using ContactBook.Models;

namespace ContactBook.Services;

/// <summary> Источник данных для контактов (вместо БД и пр.) </summary>
public class MockDataService : IContactDataService {

    private IEnumerable<Contact> _contacts;

    public MockDataService() {
        _contacts = new List<Contact>() {
            new Contact {
                Name         = "John Doe",
                PhoneNumbers = new string[] { "555-111-1111", "555-222-2222"},
                Emails       = new string[] { "Johndoe@personal.com", "Johndoe@business.com" },
                Locations    = new string[] { "111 Fake Street", "222 Fake Ave" }
            },
            new Contact {
                Name         = "Jane Doe",
                PhoneNumbers = new string[] { "555-333-3333", "555-444-4444" },
                Emails       = new string[] { "Janedoe@personal.com", "Janedoe@business.com" },
                Locations    = new string[] { "111 Fake Street", "333 Fake Ave" }
            },
            new Contact {
                Name         = "Timmy Timpson",
                PhoneNumbers = new string[] { "555-222-3113", "555-888-4123" },
                Emails       = new string[] { "Timmi@personal.com", "Timmi@business.com" },
                Locations    = new string[] { "123 Fake Street", "456 Fake Ave" }
            },
        };
    }

    public IEnumerable<Contact> GetContacts() => _contacts;
    public void Save(IEnumerable<Contact> contacts) => _contacts = contacts;
}
