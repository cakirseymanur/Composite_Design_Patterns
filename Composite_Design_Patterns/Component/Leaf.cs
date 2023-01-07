using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.Component
{
    public class Leaf : IComponent
    {
        public Leaf(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int Count()
        {
            return 1;
        }

        public string Display()
        {
            return $"<li class='list-group-item'>{Name}</li>";
        }
    }
}
