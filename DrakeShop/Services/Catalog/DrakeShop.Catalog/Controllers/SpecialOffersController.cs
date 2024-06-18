using DrakeShop.Catalog.Entities;
using DrakeShop.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrakeShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public ActionResult<List<SpecialOffer>> GetAllSpecialOffers()
        {
            var categories = _specialOfferService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOffer>> GetSpecialOfferById(string id)
        {
            var SpecialOffer = await _specialOfferService.GetById(id);
            if (SpecialOffer == null)
                return NotFound();

            return Ok(SpecialOffer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(SpecialOffer specialOffer)
        {
            await _specialOfferService.Create(specialOffer);
            return CreatedAtAction(nameof(GetSpecialOfferById), new { id = specialOffer.Id }, specialOffer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(SpecialOffer specialOffer)
        {
            await _specialOfferService.Update(specialOffer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var existingSpecialOffer = await _specialOfferService.GetById(id);
            if (existingSpecialOffer == null)
                return NotFound();

            await _specialOfferService.Delete(id);
            return NoContent();
        }
    }
}
