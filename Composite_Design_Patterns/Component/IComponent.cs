using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.Component
{
    public interface IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        int Count();
        string Display();
    }
}
