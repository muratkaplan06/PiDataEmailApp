using Microsoft.AspNetCore.Mvc;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;

namespace PiDataEmailApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EpostaAdresiController : ControllerBase
    {
        private readonly IEpostaAdresiService _epostaAdresiService;
        
        public EpostaAdresiController(IEpostaAdresiService epostaAdresiService)
        {
            _epostaAdresiService = epostaAdresiService;
        }
        
        [HttpGet]
        public async Task<IActionResult> EpostaAdresleri()
        {
            var response = await _epostaAdresiService.GetAll();
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        
        [HttpGet("{id}")]
        public IActionResult EpostaAdresi(int id)
        {
            var response = _epostaAdresiService.GetById(id);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPost]
        public IActionResult EpostaAdresiEkle([FromBody] EpostaAdresiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = _epostaAdresiService.Create(model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        
        [HttpPost]
        public IActionResult EpostaAdresiEkleList([FromBody] List<EpostaAdresiModel> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = _epostaAdresiService.CreateList(model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        
        [HttpPut("{id}")]
        public IActionResult EpostaAdresiGuncelle(int id, [FromBody] EpostaAdresiModel model)
        {
            var response = _epostaAdresiService.Update(id, model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> EpostaAdresiSil(int id)
        {
            await _epostaAdresiService.Delete(id);
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
    }
}
