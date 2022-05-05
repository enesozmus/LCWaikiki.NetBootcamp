using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;
using SecondWebAPI.Entities.Common;
using SecondWebAPI.ViewModels;
using System.Net;

namespace SecondWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        private readonly SecondDbContext _context;
        private readonly IMapper _mapper;


        public ProductsController(SecondDbContext context, IMapper mapper, IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _context = context;
            _mapper = mapper;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }



        #region [HttpGet]
        // ***** Bütün ürünleri ViewModel'den listele
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsViewModel>>> GetProducts()
        {
            var products = await _productReadRepository.GetAllAsync();
            
            var vmProducts = _mapper.Map<List<ProductsViewModel>>(products);
            return Ok(vmProducts);
        }




        // ***** Alınan ID'ye göre ait oldukları --kategori isimlerini de göstererek-- daha detaylı bir şekilde ürünü göster
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
                if (id <= 0) return BadRequest("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");
            var product = await _productReadRepository.GetProductsWithCategoryName(id);
                if (product == null) return BadRequest("Aradığınız ID'li ürün bulunamadı!"); 
            
            var vmProduct = _mapper.Map<GetProductDetailQuery>(product);
            return Ok(vmProduct);
        }



        // ***** Alınan isme göre ürünü ara => varsa göster => yoksa uyar
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] SomeQuery search)
        {
            IQueryable<Product> query = _context.Products;

                if (!string.IsNullOrEmpty(search.Name)) { query = query.Where(e => e.Name.Contains(search.Name)); }

            var response = await query.ToListAsync();
            var vmQuery = _mapper.Map <IReadOnlyList<ProductsViewModel>>(response);

                if (!vmQuery.Any()) return NotFound("Aradığınız ürün bulunamadı.");
            return Ok(vmQuery);
        }
        #endregion


        #region [HttpPost] and [HttpPut]
        [HttpPost]
        public async Task<ActionResult<CreateProductCommand>> AddProducts(CreateProductCommand newProduct)
        {
           var categoryId = _context.Categories.SingleOrDefault(x => x.Id == newProduct.CategoryId);
                if (categoryId == null) { throw new InvalidOperationException("Eklemeye çalıştığınız kategori mevcut değil."); }

            var product = _mapper.Map<Product>(newProduct);

            // ***** ModelState.IsValid ***** //
            if (ModelState.IsValid)
            {
                await _productWriteRepository.AddAsync(product);
                return StatusCode((int)HttpStatusCode.Created, "Ürün ekleme işlemi başarılı!");
            }

            return BadRequest("İşlem başarısız oldu");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducts(int id, [FromBody] UpdateProductCommand updatedProduct)
        {
            // *****  null kontrolü ***** //
            if (id != updatedProduct.Id) { return BadRequest("Girdiğiniz ID'ler eşleşmedi."); }
            var categoryId = _context.Categories.SingleOrDefault(x => x.Id == updatedProduct.CategoryId);
                if (categoryId == null) { throw new InvalidOperationException("Ürünü eklemeye çalıştığınız kategori mevcut değil."); }

            // *****  mapping ve güncelleme işlemi ***** //
            Product product = await _productReadRepository.GetByIdAsync(updatedProduct.Id);
            if (product == null) { return NotFound(); }

            // ***** ModelState.IsValid ***** //
            if (ModelState.IsValid)
            {
                product.Name = updatedProduct.Name;
                product.Brand = updatedProduct.Brand;
                product.Stock = updatedProduct.Stock;
                product.Price = updatedProduct.Price;
                await _productWriteRepository.SaveAsync();
            }
                       
            return Ok("Ürün bilgisi başarıyla güncellendi");
        }
        #endregion


        #region [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productWriteRepository.RemoveAsync(id);
            return Ok("Ürün başarıyla silindi");
        }
        #endregion



        // ***** Alınan ID'ye göre kategoriye ait olan bütün ürünleri listele
        [HttpGet("ByCategoryId")]
        public async Task<ActionResult<IEnumerable<GetProductsVMByCategory>>> GetProductsByCategoryId(int id)
        {
            // *****  null kontrolü ***** //
            var categoryId = _context.Categories.SingleOrDefault(x => x.Id == id);
            //var categoryId = _categoryReadRepository.GetSingleAsync(x => x.Id == id);
            if (categoryId == null) return BadRequest("Ürünlerini listelemeye çalıştığınız kategori mevcut değil.");

            // ***** istenen kategorinin ürünlerini listele ardından maple ***** //
            var productList = await _productReadRepository.GetProductsByCategoryId(id);
            var vmProductList = _mapper.Map<List<GetProductsVMByCategory>>(productList);

            // ****** kategori var ama boşsa kullanıcı bilgilendirildi ***** //
            if (!productList.Any()) return Ok("Ürünlerini listelemeye çalıştığınız kategori herhangi bir ürün içermiyor.");
            else return Ok(vmProductList);
        }
    }
}
