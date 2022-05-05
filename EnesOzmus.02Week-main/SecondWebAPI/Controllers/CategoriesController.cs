using AutoMapper;
using SecondWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.Entities;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SecondWebAPI.DBOperations;

namespace SecondWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly private ICategoryWriteRepository _categoryWriteRepository;
        readonly private ICategoryReadRepository _categoryReadRepository;
        readonly private SecondDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, IMapper mapper, SecondDbContext dbcontext)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
            _dbcontext = dbcontext;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriesViewModel>>> GetCategories()
        {
            var categories = await _categoryReadRepository.GetAllAsync();
            var vmCategories = _mapper.Map<List<CategoriesViewModel>>(categories);
            return Ok(vmCategories);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriesViewModel>> GetCategory(int id)
        {
            if (id <= 0) return BadRequest("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");
            var category = await _categoryReadRepository.GetByIdAsync(id, false);
            if (category == null) return BadRequest("Aradığınız ID'li kategori bulunamadı!");
            var vmCategory = _mapper.Map<CategoriesViewModel>(category);
            return Ok(vmCategory);
        }



        [HttpPost]
        public async Task<ActionResult<CreateCategoryCommand>> CreateCategory(CreateCategoryCommand categoryCommand)
        {
            var newCategory = _mapper.Map<Category>(categoryCommand);

            // *****  IsValid ***** //
            if (ModelState.IsValid)
            {
                await _categoryWriteRepository.AddAsync(newCategory);
                return StatusCode((int)HttpStatusCode.Created, "Kategori ekleme işlemi başarıyla gerçekleşti!");
            }

            return BadRequest("İşlem başarısız oldu");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryCommand updatedCategory)
        {
            if (id != updatedCategory.Id) { return BadRequest("İşlem kısıtlandı. Girdiğiniz ID'ler eşleşmedi."); }

            var category = await _categoryReadRepository.GetByIdAsync(updatedCategory.Id);
            if (category == null) { return NotFound(); }

            // *****  IsValid ***** //
            if (ModelState.IsValid)
            {
                category.Name = updatedCategory.Name;
                category.Description = updatedCategory.Description;
                await _categoryWriteRepository.SaveAsync();
            }

            return Ok("Kategori bilgisi başarıyla güncellendi");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool isEmpty = _dbcontext.Products.Include(p => p.Category).Any(m => m.Category.Id == id);
            if (isEmpty) return BadRequest("Tehlikeli bir işlem yapıyorsunuz yüzlerce ürünü kaybedebilirsniz. Lütfen önce silmeye çalıştığınız kategoriye dahil tüm ürünleri silerek devam ediniz.");
            
            await _categoryWriteRepository.RemoveAsync(id);
            return Ok("Kategori bilgisi başarıyla silindi");
        }
    }
}