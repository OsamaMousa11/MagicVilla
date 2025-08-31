using MagicVilla.Core.Domain.Entites;
using MagicVilla.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[{{VillaApi}]")]
    [ApiController]
    public class ValliaAPIContoller: ControllerBase
    {
        [HttpGet]

        public IEnumerable<VillaResponse>GetVillas()
        {
            return new List<VillaResponse>()
            { 
            };
             
        }
    }
}
