using MagicVilla.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Core.Domain.RepositoriyContracts
{
    public  interface IVillasRespository
    {
        Task<List<Villa>> GetAllVillas();
        Task <Villa> GetVilla(int villaId);
        Task CreateVilla(Villa villa);

    }
}
