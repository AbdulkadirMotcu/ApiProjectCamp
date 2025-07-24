using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsControler : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsControler(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList() { 
            var values = _context.Contacts.ToList();
            return Ok(values);
        }

        //Manuel Map'leme
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto) { 
            Contact contact = new Contact();
            contact.Email = createContactDto.Email;
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id) {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            return Ok("Silme işlemi başarılı");

        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)     
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        //Manuel Map'leme
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto) 
        {
            Contact contact = new Contact();
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi tamamlandı");

        }

        
    }
}
