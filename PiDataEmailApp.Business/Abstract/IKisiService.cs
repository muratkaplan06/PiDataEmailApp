using PiDataEmailApp.Business.Models;

namespace PiDataEmailApp.Business.Abstract;

public interface IKisiService
{
    Task<ResponseModel<List<KisiModel>>> GetAll();
    ResponseModel<KisiModel> GetById(int id);
    ResponseModel<KisiModel> Create(KisiModel model);
    ResponseModel<NoContentModel> CreateList(List<KisiModel> model);
    ResponseModel<KisiModel> Update(int id, KisiModel model);
    Task Delete(int id);
}