using DrakeShop.Contact.Dtos;
using DrakeShop.Contact.Models;
using DrakeShop.Contact.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactMessagesController : ControllerBase
    {
        private readonly IContactMessageRepository _repository;

        public ContactMessagesController(IContactMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactMessage>>> GetAllMessages()
        {
            var messages = await _repository.GetAllMessages();
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<ContactMessage>> CreateMessage(ContactMessageDto messageDto)
        {
            var message = new ContactMessage
            {
                Name = messageDto.Name,
                Email = messageDto.Email,
                Message = messageDto.Message,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddMessage(message);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllMessages), new { id = message.Id }, message);
        }
    }
}
