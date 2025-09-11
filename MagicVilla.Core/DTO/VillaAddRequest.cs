﻿using MagicVilla.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Core.DTO
{
    public  class VillaAddRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Villa Name is required.")]
        [MaxLength(100, ErrorMessage = "Villa Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public Villa Tovilla()
        {
            return new Villa
            {
                Id = this.Id,
                Name = this.Name,

            };
        }
    }
}
