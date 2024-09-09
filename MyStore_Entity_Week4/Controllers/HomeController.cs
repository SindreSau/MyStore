using Microsoft.AspNetCore.Mvc;
using MyStore_Entity_Week4.Data;
using MyStore_Entity_Week4.Models;

namespace MyStore_Entity_Week4.Controllers;

public class HomeController(ItemDbContext db) : Controller
{
    public IActionResult Index()
    {
        var carouselItems = db.Items.ToList().GetRange(0, 3);
        return View(carouselItems);
    }
}