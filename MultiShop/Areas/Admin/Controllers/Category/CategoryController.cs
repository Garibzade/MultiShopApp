using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DataAccesLayer;
using MultiShop.Extensions;
using MultiShop.Models;
using MultiShop.ViewModels;
using MultiShop.ViewModels.Categories;



namespace MULTISHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(MultiContext _context, IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.Where(c=>c.IsDelete).Select(s => new GetCategoryVM
            {
                Name = s.Name,
                Image = s.ImageUrl,
                Id = s.Id,


            }
            ).ToListAsync();

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM data)
        {

            if (!data.ImageFile.IsValidType("image"))
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir");
            if (!data.ImageFile.IsValidLenght(400))
                ModelState.AddModelError("ImageFile", "Filenin olcusu 200kbdan cox olmamalidir");
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            string fileName = await data.ImageFile.SaveImg(Path.Combine(_env.WebRootPath, "imgs", "category"));

            Category category = new Category
            {


                ImageUrl = Path.Combine("imgs", "categories", fileName),
                Name = data.Name,
                IsDelete = false,
                CreateDateTime = DateTime.Now,


            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest();
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            UpdateCategoryVm vm = new UpdateCategoryVm { ChangeName = category.Name };
            return View(vm);
           
        }
        [HttpPost]

        public async Task<IActionResult> Update(int? id,GetCategoryVM vm)
        {
            if (id is null || id<1)
            {
              return  BadRequest();

            }
            Category category = await _context.Categories.FirstOrDefaultAsync();
            if (category is null)
            {
                return NotFound();
            }
            category.Name=vm.Name;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id<1)
            {
               return BadRequest();
            }
            var delete = await _context.Categories.FindAsync(id);
            if (delete is null)
            {
                return NotFound();
            }
            _context.Categories.Remove(delete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
    }
}
