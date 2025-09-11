using MagicVilla.Core.Domain.Entites;
using MagicVilla.Core.Domain.RepositoriyContracts;
using MagicVilla.Core.DTO;
using MagicVilla.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace MagicVilla.Infrastructure.Repostitories
{
    public class VillaRepostitory : IVillasRespository
    {
        private readonly AppDbContext _db;
        public VillaRepostitory(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateVilla(Villa villa)
        {
            await _db.Villas.AddAsync(villa);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int villaId)
        {
            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == villaId);
            if (villa != null)
            {
                _db.Villas.Remove(villa);
                await _db.SaveChangesAsync();
            }
        }


        public async Task<List<Villa>> GetAllVillas()
        {
            return await _db.Villas.ToListAsync();
        }

  

        public async Task<Villa?> GetVilla(int villaId)
        {
            return await _db.Villas.FirstOrDefaultAsync(v => v.Id == villaId);
        }

        public async Task<Villa?> UpdateAsync(int id, Villa villa)
        {
         
            var existingVilla = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

           
            if (existingVilla == null) return null;

            _db.Entry(existingVilla).CurrentValues.SetValues(villa);

            await _db.SaveChangesAsync();

            return existingVilla;
        }
    }
}
