using PiDataEmailApp.Business.Models;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Abstract;

public interface IKisiService
{
    Task<ResponseModel<List<Kisi>>> GetAll();
    Task<ResponseModel<List<Kisi>>> GetAllByFilter(string? cinsiyet, int? yasMin, int? yasMax);
    ResponseModel<KisiModel> GetById(int id);
    ResponseModel<KisiModel> Create(KisiModel model);
    ResponseModel<NoContentModel> CreateList(List<KisiModel> model);
    ResponseModel<KisiModel> Update(int id, KisiModel model);
    Task Delete(int id);
}