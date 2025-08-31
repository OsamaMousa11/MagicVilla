using MagicVilla.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Core.DTO
{
    public class VillaUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Villa ToVilla()
        {
           return new Villa
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}

      
