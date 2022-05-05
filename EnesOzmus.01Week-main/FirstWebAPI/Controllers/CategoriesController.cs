using AutoMapper;
using FirstWebAPI.DBOperations;
using FirstWebAPI.Models;
using FirstWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                                                    .OrderBy(x => x.Id)
                                                    .ToListAsync();

            var vmCategories = _mapper.Map<List<VM_Get_Categories>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<VM_Get_Categories>>.Success(200, vmCategories));
        }




        // GET api/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (id <= 0)
                return CreateActionResult(CustomResponseDto<VM_Get_Categories>.Fail(400, "Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!"));

            var category = await _context.Categories
                                                .SingleOrDefaultAsync(m => m.Id == id);
                                                
            if (category == null)
                return CreateActionResult(CustomResponseDto<VM_Get_Categories>.Fail(404, "Aradığınız ID'li ürün bulunamadı!"));

            var vmCategory = _mapper.Map<VM_Get_Categories>(category);

            return CreateActionResult(CustomResponseDto<VM_Get_Categories>.Success(200, vmCategory));
        }




        //POST api/categories
        [HttpPost]
        public async Task<IActionResult> AddCategories(VM_Create_Category newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return CreateActionResult(CustomResponseDto<VM_Create_Category>.Success(201, newCategory));
        }




        //PUT api/categories
        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Category updatedCategory)
        {
            _context.Categories.Update(_mapper.Map<Category>(updatedCategory));
            await _context.SaveChangesAsync();

            return Ok("Ürün başarıyla güncellendi");
        }




        //DELETE api/categories
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            if (id <= 0)
                return CreateActionResult(CustomResponseDto<VM_Get_Categories>.Fail(400, "Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!"));

            var category = await _context.Categories
                                                    .SingleOrDefaultAsync(m => m.Id == id);
                                                    
            if (category == null)
                return CreateActionResult(CustomResponseDto<VM_Get_Categories>.Fail(404, "Silmeye çalıştığınız ID'li ürün bulunamadı!"));

            bool isCategoryAnyProducts = _context.Products.Include(p => p.Category).Any(m => m.Category.Id == category.Id);
            if (isCategoryAnyProducts)
                return CreateActionResult(CustomResponseDto<VM_Get_Categories>.Fail(400, "Tehlikeli bir işlem yapıyorsunuz yüzlerce ürünü kaybedebilirsniz. Lütfen önce silmeye çalıştığınız kategoriye dahil tüm ürünleri silerek devam ediniz."));

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok("Kategori başarıyla silindi");
        }


        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Category>>> Search([FromQuery] SomeQuery search)
        {
            IQueryable<Category> query = _context.Categories;

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(e => e.Name.Contains(search.Name));
            }

            var vmQuery = _mapper.Map<List<VM_Get_Categories>>(query.ToList());
            if (!vmQuery.Any())
                return NotFound();
            return Ok(vmQuery);
        }
    }
}
