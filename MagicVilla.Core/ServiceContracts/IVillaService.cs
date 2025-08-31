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
    }
}
