using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Abstract;

public interface IKisiDal:IEntityRepository<Kisi>
{
    Task<List<Kisi>> GetAllByFilter(string? cinsiyet, int? yasMin, int? yasMax);
    
}