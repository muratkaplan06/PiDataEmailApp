using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete.EntityFramework;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Concrete.Dal
{
    public class EpostaGonderimDetayDal:EfEntityRepository<EpostaGonderimDetay,PiDataDbContext>,IEpostaGonderimDetayDal
    {
        public EpostaGonderimDetayDal(PiDataDbContext context) : base(context)
        {
        }
    }
}
