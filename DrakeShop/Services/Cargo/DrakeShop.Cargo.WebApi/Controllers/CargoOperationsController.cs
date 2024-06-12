using DrakeShop.Cargo.BusinessLayer.Abstract;
using DrakeShop.Cargo.DtoLayer.CargoOperationDto;
using DrakeShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(CargoOperation);
            return Ok("Kargo detay ekleme başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperationById(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Detay Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto cargoOperationDto)
        {
            CargoOperation customer = new CargoOperation()
            {
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                OperationDate = cargoOperationDto.OperationDate,
                CargoOperationId = cargoOperationDto.CargoOperationId,
            };
            _cargoOperationService.TUpdate(customer);
            return Ok("Kargo detay güncelleme işlemi başarılı.");
        }
    }
}
