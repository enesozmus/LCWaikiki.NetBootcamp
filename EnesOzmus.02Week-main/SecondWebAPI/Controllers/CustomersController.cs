using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.Entities;
using SecondWebAPI.ViewModels;
using System.Net;

namespace SecondWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository, IMapper mapper)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersViewModel>>> GetCustomers()
        {
            var customers = await _customerReadRepository.GetAllAsync();
            var vmCustomers = _mapper.Map<List<CustomersViewModel>>(customers);
            return Ok(vmCustomers);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CustomersViewModel>> GetCustomer(int id)
        {
            if (id <= 0) return BadRequest("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");
            var customer = await _customerReadRepository.GetByIdAsync(id, false);
            if (customer == null) return BadRequest("Aradığınız ID'li müşteri bulunamadı!");
            var vmCustomer = _mapper.Map<CustomersViewModel>(customer);
            return Ok(vmCustomer);
        }



        [HttpPost]
        public async Task<ActionResult<CreateCustomerCommand>> Createcustomer(CreateCustomerCommand customerCommand)
        {
            var newCustomer = _mapper.Map<Customer>(customerCommand);

            // *****  IsValid ***** //
            if (ModelState.IsValid)
            {
                await _customerWriteRepository.AddAsync(newCustomer);
                return StatusCode((int)HttpStatusCode.Created, "Müşteri ekleme işlemi başarıyla gerçekleşti!");
            }

            return BadRequest("İşlem başarısız oldu");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerCommand updatedCustomer)
        {
            if (id != updatedCustomer.Id) { return BadRequest("İşlem kısıtlandı. Girdiğiniz ID'ler eşleşmedi."); }


            var customer = await _customerReadRepository.GetByIdAsync(updatedCustomer.Id);
            if (customer == null) { return NotFound(); }
            // *****  IsValid ***** //
            if (ModelState.IsValid)
            {
                customer.FullName = updatedCustomer.FullName;
                customer.EMail = updatedCustomer.EMail;
                customer.PhoneNumber = updatedCustomer.PhoneNumber;
                await _customerWriteRepository.SaveAsync();
            }
            
            return Ok("Müşteri bilgisi başarıyla güncellendi");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerWriteRepository.RemoveAsync(id);
            return Ok("Müşteri bilgisi başarıyla silindi");
        }
    }
}
