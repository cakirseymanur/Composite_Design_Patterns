using Composite_Design_Patterns.Component;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.Component
{
    public class Composite : IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private List<IComponent> _components;

        public IReadOnlyCollection<IComponent> Components => _components;

        public Composite(int id, string name)
        {
            Id = id;
            Name = name;
            _components = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }

        public int Count()
        {
            return _components.Sum(x => x.Count());
        }

        public string Display()
        {
            var sb = new StringBuilder();
            sb.Append($"<div class='text-primary my-1'><a href='#' class='menu'>   {Name} ({Count()}) </a></div>");

            if (!_components.Any()) return sb.ToString();

            sb.Append("<ul class='list-group list-group-flush ml-3'>");

            foreach (var item in _components)
            {
                sb.Append(item.Display());
            }

            sb.Append("</ul>");

            return sb.ToString();
        }

        public List<SelectListItem>GetSelectListItems(string line)
        {
            var list = new List<SelectListItem> { new($"{line}{Name}", Id.ToString()) };

            if (_components.Any(x => x is Composite))
            { line += " - "; }

            _components.ForEach(x =>
            {
                if (x is Composite bookComposite)
                {
                    list.AddRange(bookComposite.GetSelectListItems(line));
                }
            });
            return list;
        }
    }
}
