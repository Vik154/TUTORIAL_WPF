using Bookinist.DAL.Entityes.Base;

namespace Bookinist.DAL.Entityes;

public class Book : NamedEntity {

    // virtual - нужно для ленивой загрузки, EF не будет заполнять их
    // только при обращении к БД будут сформированы объекты
    public virtual Category Category { get; set; }

    public override string ToString() => $"Книга {Name}";
}
