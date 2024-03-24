using Microsoft.AspNetCore.Mvc;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;

namespace PiDataEmailApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EpostaAdresiGonderimController : ControllerBase
    {
        private readonly IEpostaGonderimService _epostaGonderimService;
        
        public EpostaAdresiGonderimController(IEpostaGonderimService epostaGonderimService)
        {
            _epostaGonderimService = epostaGonderimService;
        }
        
        [HttpGet]
        public async Task<IActionResult> EpostaAdresiGonderimler()
        {
            var response = await _epostaGonderimService.GetAll();
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        
        [HttpGet("{id}")]
        public IActionResult EpostaAdresiGonderim(int id)
        {
            var response = _epostaGonderimService.GetById(id);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPost]
        public async Task<IActionResult> Gonder([FromBody] EpostaGonderimModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _epostaGonderimService.Create(model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPost]
        public IActionResult EpostaAdresiGonderimEkleList([FromBody] List<EpostaGonderimModel> model)
        {
            var response = _epostaGonderimService.CreateList(model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpPut("{id}")]
        public IActionResult EpostaAdresiGonderimGuncelle(int id, [FromBody] EpostaGonderimModel model)
        {
            var response = _epostaGonderimService.Update(id, model);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EpostaAdresiGonderimSil(int id)
        {
            await _epostaGonderimService.Delete(id);
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
    }
}
