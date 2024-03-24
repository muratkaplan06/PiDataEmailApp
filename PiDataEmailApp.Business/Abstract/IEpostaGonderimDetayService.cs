using PiDataEmailApp.Business.Models;

namespace PiDataEmailApp.Business.Abstract
{
    public interface IEpostaGonderimDetayService
    {
        Task<ResponseModel<List<EpostaGonderimDetayModel>>> GetAll();
        Task<ResponseModel<List<EpostaGonderimDetayWithIncludeModel>>> GetAllWithIncludesAsync();
        ResponseModel<EpostaGonderimDetayModel> GetById(int id);
        Task Delete(int id);
    }
}
