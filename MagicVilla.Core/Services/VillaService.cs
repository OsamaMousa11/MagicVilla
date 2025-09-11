using AutoMapper;
using MagicVilla.Core.Domain.Entites;
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
      
        public VillaService(IVillasRespository villaRepository)
        {
            _villaRepository = villaRepository;
        }

        public  async Task<VillaResponse> AddVilla(VillaAddRequest villaRequest)
        {
            if(villaRequest == null)
            {
                throw new ArgumentNullException(nameof(villaRequest));
            }

            var exisingVilla= (await _villaRepository.GetAllVillas())
             .FirstOrDefault(c => c.Name.Equals(villaRequest.Name, StringComparison.OrdinalIgnoreCase));
            if(exisingVilla!=null)
            {
                 throw new Exception("Villa already exists");
            }
            var villa=villaRequest.Tovilla();
            await _villaRepository.CreateVilla(villa);
            return villa.ToVillaResponse();

        }

        public async Task<bool> DeleteVila(int villaId)
        {
            var villa = await _villaRepository.GetVilla(villaId);
            if (villa == null)return false;
            await _villaRepository.DeleteAsync(villaId);
            return true;
                }
        

        public async Task<List<VillaResponse>> GetAllVillas()
        {
            List<Villa> villas = await _villaRepository.GetAllVillas();
            return villas.Select(v => v.ToVillaResponse()).ToList();


        }

        public  async Task<VillaResponse?> GetVillabyId(int villaId)
        {
            Villa villa= await _villaRepository.GetVilla(villaId);
            return villa.ToVillaResponse();
        }

        public async Task<VillaResponse?> UpdateVilla(int id, VillaUpdateRequest villaUpdateRequest)
        {
           if(villaUpdateRequest == null || id == 0)
            {
                throw new ArgumentNullException("Invalid villa data or ID");
            }
          var matchingVilla = await _villaRepository.GetVilla(id);
            if(matchingVilla == null)
            {
                throw new Exception("Villa not found");
            }

            matchingVilla.Name = villaUpdateRequest.Name;
   
            var updatedVilla= await _villaRepository.UpdateAsync(id, matchingVilla);
            return updatedVilla.ToVillaResponse();
        }
    }
}
