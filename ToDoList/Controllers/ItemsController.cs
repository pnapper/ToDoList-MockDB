using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
		private IItemRepository itemRepo;  // New!

		public ItemsController(IItemRepository repo = null)
		{
			if (repo == null)
			{
				this.itemRepo = new EFItemRepository();
			}
			else
			{
				this.itemRepo = repo;
			}
		}

		public ViewResult Index()
		{
			// Updated:
			return View(itemRepo.Items.ToList());
		}

		public IActionResult Details(int id)
		{
			// Updated:
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Item item)
		{
			itemRepo.Save(item);   // Updated
								   // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			// Updated:
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}

		[HttpPost]
		public IActionResult Edit(Item item)
		{
			itemRepo.Edit(item);   // Updated!
								   // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			// Updated:
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			// Updated:
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			itemRepo.Remove(thisItem);   // Updated!
										 // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

        //private ToDoListContext db = new ToDoListContext();

        //public IActionResult Index()
        //{
        //    return View(db.Items.Include(items => items.Category).ToList());
        //}

        //public IActionResult Details(int id)
        //{
        //    Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
        //    return View(thisItem);
        //}

        //public IActionResult Create()
        //{
        //    ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Item item)
        //{
        //    db.Items.Add(item);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int id)
        //{
        //    var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
        //    ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
        //    return View(thisItem);
        //}

        //[HttpPost]
        //public IActionResult Edit(Item item)
        //{
        //    db.Entry(item).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int id)
        //{
        //    var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
        //    return View(thisItem);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
        //    db.Items.Remove(thisItem);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}