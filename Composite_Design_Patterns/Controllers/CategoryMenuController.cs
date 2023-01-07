using Composite_Design_Patterns.Component;
using Composite_Design_Patterns.DAL;
using Composite_Design_Patterns.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.Controllers
{
    public class CategoryMenuController : Controller
    {
        private readonly Context _context;

        public CategoryMenuController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Include(x => x.Clothes).OrderBy(x=>x.Id).ToListAsync();
            var menu = GetMenus(categories, new Category { Name = "TopCategory", Id = 0 }, new Composite(0, "TopMenu"));
            ViewBag.Menu = menu;

            ViewBag.selectList = menu.Components.SelectMany(x => ((Composite)x).GetSelectListItems(""));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(int categoryId,string clothesName)
        {
            await _context.Clothes.AddAsync(new Clothes { CategoryId = categoryId, Name = clothesName });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public Composite GetMenus(List<Category> categories, Category topCategory, Composite topClothesComposite, Composite last=null)
        {
            categories.Where(x => x.ReferansId == topCategory.Id).ToList().ForEach(categoryItem =>
            {
                var clothesComposite = new Composite(categoryItem.Id, categoryItem.Name);

                categoryItem.Clothes.ToList().ForEach(clothesItem =>
                {
                    clothesComposite.Add(new Leaf(clothesItem.Id, clothesItem.Name));
                });

                if (last != null)
                {
                    last.Add(clothesComposite);
                }
                else
                {
                    topClothesComposite.Add(clothesComposite);
                }

                GetMenus(categories, categoryItem, topClothesComposite, clothesComposite);
            });
            return topClothesComposite;
        }
    }
}
