using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete.EntityFramework;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Concrete.Dal;

public class EpostaGonderimDal:EfEntityRepository<EpostaGonderim,PiDataDbContext>,IEpostaGonderimDal
{
    public EpostaGonderimDal(PiDataDbContext context) : base(context)
    { 
    }
}