using MagicVilla.Core.Domain.Entites;
using MagicVilla.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Infrastructure.Data
{
   
    public  class DataSeeder
    {
        private readonly AppDbContext _context;
        public DataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Villas.Any())
            {
                Console.WriteLine("Seeding categories...");

                var categories = new List<Villa>
            {
                new Villa{Id=1, Name="Pool View"},
                new Villa{Id=2, Name="Beach View"}
            };

                _context.Villas.AddRange(categories);
                _context.SaveChanges();

                Console.WriteLine("Villas seeded successfully.");
            }
            else
            {
                Console.WriteLine("Villas already exist in database.");
            }
        }

    } 
}
