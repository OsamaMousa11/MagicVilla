using AutoMapper;
using MagicVilla.Core.Domain.RepositoriyContracts;
using MagicVilla.Core.DTO;
using MagicVilla.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Core.Services
{
    public class VillaService : IVillaService
    {  
        private readonly IVillasRespository _villaRepository;
        private readonly IMapper _mapper;
        public VillaService(IVillasRespository villaRepository)
        {
            _villaRepository = villaRepository;
        }
        public async Task<List<VillaResponse>> GetAllVillas()
        {
            var villas = await _villaRepository.GetAllVillas();
            return _mapper.Map<List<VillaResponse>>(villas);

        }
    }
}
