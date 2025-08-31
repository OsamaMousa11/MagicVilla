using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Core.DTO
{
    public class VillaResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
      public DateTime CreatedDate { get; set; }

        public  VillaUpdateRequest ToVillaUpdateRequest()
        {
            return new VillaUpdateRequest
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
    public static class VillaResponseExtension
    {
        public static VillaResponse ToVillaResponse(this Domain.Entites.Villa villa)
        {
            return new VillaResponse
            {
                Id = villa.Id,
                Name = villa.Name,
                CreatedDate = villa.CreatedDate
            };
        }
    }
}
