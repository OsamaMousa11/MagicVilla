using MagicVilla.Core.Domain.Entites;
using MagicVilla.Core.Domain.RepositoriyContracts;
using MagicVilla.Core.DTO;
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

        public  async Task CreateVilla(Villa villa)
        {
           await _db.Villas.AddAsync(villa);
              await _db.SaveChangesAsync();
        }

        public async Task<List<Villa>> GetAllVillas()
        {
           return await _db.Villas.ToListAsync();
        }

        public  async  Task<Villa> GetVilla(int villaId)
        {
           return await _db.Villas.FirstOrDefaultAsync(v=>v.Id==villaId);
        }
    }
}
