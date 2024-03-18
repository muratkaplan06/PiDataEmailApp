using Microsoft.EntityFrameworkCore;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete.EntityFramework;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.DataAccess.Concrete.Dal;

public class KisiDal : EfEntityRepository<Kisi, PiDataDbContext>, IKisiDal
{
    private readonly PiDataDbContext _context;
    public KisiDal(PiDataDbContext context) : base(context)
    {
        _context = context;

    }

    public async Task<List<Kisi>> GetAllByFilter(string? cinsiyet, int? yasMin, int? yasMax)
    {
        return await _context.Kisiler.Where(x =>
            (cinsiyet == null || x.Cinsiyet == cinsiyet)
            && (yasMin == null || yasMin == 0 || x.Yas >= yasMin)
            && (yasMax == null || yasMax == 0 || x.Yas <= yasMax))
            .ToListAsync();

    }
}