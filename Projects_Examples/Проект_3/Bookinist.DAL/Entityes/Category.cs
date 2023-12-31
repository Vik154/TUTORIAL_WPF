﻿using Bookinist.DAL.Entityes.Base;

namespace Bookinist.DAL.Entityes;

public class Category : NamedEntity {
    public virtual ICollection<Book> Books { get; set; }

    public override string ToString() => $"Категория {Name}";
}
