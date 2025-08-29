using MagicVilla.Core.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class ValliaAPIContoller: ControllerBase
    {
        [HttpGet]

        public IEnumerable<Villa>GetVillas()
        {
            return new List<Villa>()
            {
                new Villa{Id=1, Name="Pool View"},
                new Villa{Id=2, Name="Beach View"}
            };

        }
    }
}
