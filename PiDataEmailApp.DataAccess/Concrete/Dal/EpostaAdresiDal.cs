using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete.EntityFramework;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Concrete.Dal;

public class EpostaAdresiDal:EfEntityRepository<EpostaAdresi,PiDataDbContext>,IEpostaAdresiDal
{
    public EpostaAdresiDal(PiDataDbContext context) : base(context)
    {
    }
}