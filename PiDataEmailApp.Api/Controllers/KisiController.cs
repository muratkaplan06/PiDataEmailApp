using Microsoft.AspNetCore.Mvc;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;

namespace PiDataEmailApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private readonly IKisiService _kisiService;
        
        public KisiController(IKisiService kisiService)
        {
            _kisiService = kisiService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Kisiler()
        {
            var response = await _kisiService.GetAll();
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        
        [HttpGet("{id}")]
        public IActionResult Kisi(int id)
        {
            var response = _kisiService.GetById(id);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPost]
        public IActionResult KisiEkle([FromBody] KisiModel model)
        {
            var response = _kisiService.Create(model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPost]
        public IActionResult KisiEkleList([FromBody] List<KisiModel> model)
        {
            var response = _kisiService.CreateList(model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPut("{id}")]
        public IActionResult KisiGuncelle(int id, [FromBody] KisiModel model)
        {
            var response = _kisiService.Update(id, model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> KisiSil(int id)
        {
            await _kisiService.Delete(id);
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
    }
}
