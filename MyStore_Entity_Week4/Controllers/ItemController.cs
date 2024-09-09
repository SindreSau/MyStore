using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore_Entity_Week4.Data;
using MyStore_Entity_Week4.Models;
using MyStore_Entity_Week4.ViewModels;

namespace MyStore_Entity_Week4.Controllers;

public class ItemController(ItemDbContext db) : Controller
{
    public async Task<IActionResult> Table(string searchString)
    {
        var items = await FilterItems(searchString);

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            return PartialView("_ItemTable", items);

        var itemsViewModel = new ItemsViewModel(items, "Table");
        ViewData["CurrentFilter"] = searchString;
        return View(itemsViewModel);
    }

    public async Task<IActionResult> Grid(string searchString)
    {
        var items = await FilterItems(searchString);

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            return PartialView("_GridContent", new ItemsViewModel(items, "Grid"));

        var itemsViewModel = new ItemsViewModel(items, "Grid");
        ViewData["CurrentFilter"] = searchString;
        return View(itemsViewModel);
    }

    private async Task<List<Item>> FilterItems(string searchString)
    {
        var items = from i in db.Items
            select i;

        if (!string.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            items = items.Where(s => EF.Functions.Like(s.Name.ToLower(), $"%{searchString}%")
                                     || EF.Functions.Like(s.Description.ToLower(), $"%{searchString}%"));
        }

        return await items.ToListAsync();
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await db.Items.FirstOrDefaultAsync(i => i.ItemId == id);

        if (item == null) return NotFound();

        return View(item);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        if (ModelState.IsValid)
        {
            db.Items.Add(item);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Item item)
    {
        if (ModelState.IsValid)
        {
            db.Items.Update(item);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await db.Items.FirstOrDefaultAsync(i => i.ItemId == id);

        if (item == null) return NotFound();

        db.Items.Remove(item);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }
}