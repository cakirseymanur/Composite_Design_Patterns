using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.DAL.Entities
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
