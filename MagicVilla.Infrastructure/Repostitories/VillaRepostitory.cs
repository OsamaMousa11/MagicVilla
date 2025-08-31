using MagicVilla.Core.Domain.Entites;
using MagicVilla.Core.Domain.RepositoriyContracts;
using MagicVilla.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace MagicVilla.Infrastructure.Repostitories
{
    public class VillaRepostitory : IVillasRespository
    {   private readonly AppDbContext _db;
        public VillaRepostitory(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Villa>> GetAllVillas()
        {
           return await _db.Villas.ToListAsync();
        }
    }
}
