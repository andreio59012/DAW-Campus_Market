using CampusMarket.Data;
using CampusMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusMarket.Controllers;

public class CategoriesController : Controller
{
    private readonly ApplicationDbContext db;

    public CategoriesController(ApplicationDbContext context)
    {
        db = context;
    }

    public async Task<IActionResult> Index()
    {
        if (TempData.ContainsKey("message"))
            ViewBag.Message = TempData["message"];

        var categories = await (from category in db.Categories
                                orderby category.CategoryName
                                select category).ToListAsync();

        ViewBag.Categories = categories;
        return View();
    }

    public async Task<IActionResult> Show(int id)
    {
        Category? category = await db.Categories.FindAsync(id);

        if (category is null)
            return NotFound();

        return View(category);
    }

    public IActionResult New() => View();

    [HttpPost]
    public async Task<IActionResult> New(Category cat)
    {
        try
        {
            db.Categories.Add(cat);
            await db.SaveChangesAsync();
            TempData["message"] = "Categoria a fost adăugată";
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return View(cat);
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        Category? category = await db.Categories.FindAsync(id);

        if (category is null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Category requestCategory)
    {
        Category? category = await db.Categories.FindAsync(id);

        if (category is null)
            return NotFound();

        try
        {
            category.CategoryName = requestCategory.CategoryName;
            await db.SaveChangesAsync();
            TempData["message"] = "Categoria a fost modificată";
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return View(requestCategory);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        Category? category = await db.Categories.FindAsync(id);

        if (category is null)
            return NotFound();

        db.Categories.Remove(category);
        await db.SaveChangesAsync();
        TempData["message"] = "Categoria a fost ștearsă";
        return RedirectToAction("Index");
    }
}
