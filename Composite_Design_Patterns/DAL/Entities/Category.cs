using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Clothes> Clothes { get; set; }

        public int ReferansId { get; set; }
    }
}
