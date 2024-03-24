using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiDataEmailApp.Business.Abstract;

namespace PiDataEmailApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EpostagonderimDetayController : ControllerBase
    {
        private readonly IEpostaGonderimDetayService _epostagonderimDetayService;

        public EpostagonderimDetayController(IEpostaGonderimDetayService epostagonderimDetayService)
        {
            _epostagonderimDetayService = epostagonderimDetayService;
        }

        [HttpGet]
        public async Task<IActionResult> EpostagonderimDetaylar()
        {
            var response = await _epostagonderimDetayService.GetAll();
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }

        [HttpGet]
        public async Task<IActionResult> EpostagonderimDetaylarWithIncludes()
        {
            var response = await _epostagonderimDetayService.GetAllWithIncludesAsync();
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }
        [HttpGet]
        public IActionResult EpostagonderimDetay(int id)
        {
            var response = _epostagonderimDetayService.GetById(id);
            return new ObjectResult(response.Data) { StatusCode = response.StatusCode };
        }

        [HttpGet]
        public async Task<IActionResult> EpostagonderimDetaySil(int id)
        {
            await _epostagonderimDetayService.Delete(id);
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        

    }
}
