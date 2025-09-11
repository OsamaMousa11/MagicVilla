using MagicVilla.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Core.ServiceContracts
{
    public  interface IVillaService
    {
        Task<List<VillaResponse>> GetAllVillas();
        Task<VillaResponse?> GetVillabyId(int villaId);
        Task<VillaResponse> AddVilla(VillaAddRequest villaAddRequest);

        Task<VillaResponse?> UpdateVilla(int id, VillaUpdateRequest villaUpdateRequest);
        Task<bool> DeleteVila(int villaId);
    }
}
