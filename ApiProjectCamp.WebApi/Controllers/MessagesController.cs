using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(ApiContext apiContext, IMapper mapper)
        {
            _context = apiContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MesaggeList() 
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));

        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message value = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj eklme işlemi başarılı");
        }


        [HttpDelete]
        public IActionResult DeleteMessage(int id) {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges(true);
            return Ok("Mesaj silindi");

        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id) {
            Message message = _context.Messages.Find(id);
            return Ok(_mapper.Map<ResultMessageDto>(message));
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto) {
            Message message = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj Güncellendi");
        }
    }
}
