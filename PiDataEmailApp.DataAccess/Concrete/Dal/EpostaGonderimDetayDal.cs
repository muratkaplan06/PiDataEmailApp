using Microsoft.EntityFrameworkCore;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete.EntityFramework;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Concrete.Dal
{
    public class EpostaGonderimDetayDal:EfEntityRepository<EpostaGonderimDetay,PiDataDbContext>,IEpostaGonderimDetayDal
    {
        private readonly PiDataDbContext _context;
        public EpostaGonderimDetayDal(PiDataDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<EpostaGonderimDetay>> GetAllWithIncludesAsync()
        {
            return _context.EpostaGonderimDetaylari
                .Include(x => x.EpostaGonderim)
                .Include(x => x.Kisi)
                .ToListAsync();
        }
    }
}
