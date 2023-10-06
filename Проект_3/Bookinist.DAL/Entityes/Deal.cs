using Bookinist.DAL.Entityes.Base;

namespace Bookinist.DAL.Entityes;

public class Deal : Entity {
    public decimal Price { get; set; }
    public virtual Book Book { get; set; }
    public virtual Seller Seller { get; set; }
    public virtual Buyer Buyer { get; set; }
}
