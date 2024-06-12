using DrakeShop.Cargo.BusinessLayer.Abstract;
using DrakeShop.Cargo.DataAccessLayer.Abstract;
using DrakeShop.Cargo.DtoLayer.CargoCustomerDtos;
using DrakeShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList() 
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id) 
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto) 
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Phone = createCargoCustomerDto.Phone,
            };
            _customerService.TInsert(cargoCustomer);
            return Ok("kargo müşteri ekleme başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomerById(int id) 
        { 
            _customerService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto cargoCustomerDto) 
        {
            CargoCustomer customer = new CargoCustomer()
            {
                Address = cargoCustomerDto.Address,
                City = cargoCustomerDto.City,
                District = cargoCustomerDto.District,
                Email = cargoCustomerDto.Email,
                Name = cargoCustomerDto.Name,
                Surname= cargoCustomerDto.Surname,
                Phone = cargoCustomerDto.Phone,
            };
            _customerService.TUpdate(customer);
            return Ok("Kargo müşteri güncelleme işlemi başarılı.");
        }

    }
}
