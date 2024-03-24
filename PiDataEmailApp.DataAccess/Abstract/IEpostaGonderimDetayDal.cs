using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Abstract
{
    public interface IEpostaGonderimDetayDal:IEntityRepository<EpostaGonderimDetay>
    {
        Task<List<EpostaGonderimDetay>> GetAllWithIncludesAsync();
    }
}
