using PiDataEmailApp.Business.Models;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Abstract;

public interface IEpostaAdresiService
{
    Task<ResponseModel<List<EpostaAdresiModel>>> GetAll();
    ResponseModel<EpostaAdresiModel> GetById(int id);
    ResponseModel<EpostaAdresiModel> Create(EpostaAdresiModel model);
    ResponseModel<NoContentModel> CreateList(List<EpostaAdresiModel> model);
    ResponseModel<EpostaAdresiModel> Update(int id, EpostaAdresiModel model);
    Task Delete(int id);
}