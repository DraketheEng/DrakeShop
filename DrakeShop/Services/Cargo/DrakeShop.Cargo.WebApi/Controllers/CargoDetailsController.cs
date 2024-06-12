using DrakeShop.Cargo.BusinessLayer.Abstract;
using DrakeShop.Cargo.DtoLayer.CargoDetailDto;
using DrakeShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
            };
            _cargoDetailService.TInsert(CargoDetail);
            return Ok("Kargo detay ekleme başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetailById(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detay Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto cargoDetailDto)
        {
            CargoDetail customer = new CargoDetail()
            {
                Barcode = cargoDetailDto.Barcode,
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                CargoDetailId = cargoDetailDto.CargoDetailId,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
                SenderCustomer = cargoDetailDto.SenderCustomer,
            };
            _cargoDetailService.TUpdate(customer);
            return Ok("Kargo detay güncelleme işlemi başarılı.");
        }
    }
}
