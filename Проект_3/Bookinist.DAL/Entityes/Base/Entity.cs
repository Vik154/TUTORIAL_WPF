using Bookinist.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.DAL.Entityes.Base;

public abstract class Entity : IEntity {
    public int Id { get; set; }
}
