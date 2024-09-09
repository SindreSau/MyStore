using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore_Entity_Week4.Data;
using MyStore_Entity_Week4.Models;
using MyStore_Entity_Week4.ViewModels;

namespace MyStore_Entity_Week4.Controllers;

public class ItemController(ItemDbContext db) : Controller
{
    public IActionResult Table()
    {
        var items = db.Items.ToList();
        var itemsViewModel = new ItemsViewModel(items, "Table");
        return View(itemsViewModel);
    }

    public IActionResult Grid()
    {
        var items = db.Items.ToList();
        var itemsViewModel = new ItemsViewModel(items, "Grid");
        return View(itemsViewModel);
    }

    public IActionResult Details(int id)
    {
        var item = db.Items.FirstOrDefault(i => i.ItemId == id);

        if (item == null) return NotFound();

        return View(item);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        if (ModelState.IsValid)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction(nameof(Table));
        }

        return View(item);
    }
}