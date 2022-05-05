using AutoMapper;
using FirstWebAPI.DBOperations;
using FirstWebAPI.Models;
using FirstWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VM_Get_Products>>> GetProducts()
        {

            var products = await _context.Products
                                                    .Include(x => x.Category)
                                                    .OrderBy(x => x.Id)
                                                    .ToListAsync();

            var vmProducts = _mapper.Map<List<VM_Get_Products>>(products.ToList());
            return Ok(vmProducts);
        }




        // GET api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (id <= 0)
                return CreateActionResult(CustomResponseDto<VM_Get_Product>.Fail(400, "Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!"));

            var product = await _context.Products
                                                .Include(x => x.Category)
                                                .Include(x => x.Features)
                                                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return CreateActionResult(CustomResponseDto<VM_Get_Product>.Fail(404, "Aradığınız ID'li ürün bulunamadı!"));

            var vmProduct = _mapper.Map<VM_Get_Product>(product);

            return CreateActionResult(CustomResponseDto<VM_Get_Product>.Success(200, vmProduct));
        }




        //POST api/products
        [HttpPost]
        public async Task<IActionResult> AddProducts(VM_Create_Product newProduct)
        {
            var categoryId = _context.Categories
                                                .SingleOrDefault(x => x.Id == newProduct.CategoryId);
                                                
            if (categoryId == null)
                throw new InvalidOperationException("Eklemeye çalıştığınız kategori mevcut değil.");

            var product = _mapper.Map<Product>(newProduct);
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreateActionResult(CustomResponseDto<VM_Create_Product>.Success(201, newProduct));
        }




        //PUT api/products
        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Product updatedProduct)
        {
            var categoryId = _context.Categories
                                                .SingleOrDefault(x => x.Id == updatedProduct.CategoryId);
                                                
            if (categoryId == null)
                throw new InvalidOperationException("Ürünü eklemeye çalıştığınız kategori mevcut değil.");

            _context.Products.Update(_mapper.Map<Product>(updatedProduct));
            await _context.SaveChangesAsync();

            return Ok("Ürün başarıyla güncellendi");
        }




        //DELETE api/products
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            if (id <= 0)
                return CreateActionResult(CustomResponseDto<VM_Get_Product>.Fail(400, "Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!"));

            var product = await _context.Products
                                                .SingleOrDefaultAsync(m => m.Id == id);
                                                
            if (product == null)
                return CreateActionResult(CustomResponseDto<VM_Get_Product>.Fail(404, "Silmeye çalıştığınız ID'li ürün bulunamadı!"));
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Ürün başarıyla silindi");
        }


        // Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] SomeQuery search)
        {
            IQueryable<Product> query = _context.Products
                                                        .Include(x => x.Category);

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(e => e.Name.Contains(search.Name));
            }

            var vmQuery = _mapper.Map<List<VM_Get_Products>>(query.ToList());
            if(!vmQuery.Any())
                return NotFound();
            return Ok(vmQuery);
        }
    }
}
