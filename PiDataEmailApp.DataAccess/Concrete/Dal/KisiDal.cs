using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete.EntityFramework;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Concrete.Dal;

public class KisiDal:EfEntityRepository<Kisi,PiDataDbContext>,IKisiDal
{
    public KisiDal(PiDataDbContext context) : base(context)
    {
    }
}