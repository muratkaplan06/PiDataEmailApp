using PiDataEmailApp.Business.Models;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Abstract;

public interface IEpostaGonderimService
{
    Task<ResponseModel<List<EpostaGonderimModel>>> GetAll();
    ResponseModel<EpostaGonderimModel> GetById(int id);
    ResponseModel<EpostaGonderimModel> Create(EpostaGonderimModel model);
    ResponseModel<NoContentModel> CreateList(List<EpostaGonderimModel> model);
    ResponseModel<EpostaGonderimModel> Update(int id, EpostaGonderimModel model);
    Task Delete(int id);
}