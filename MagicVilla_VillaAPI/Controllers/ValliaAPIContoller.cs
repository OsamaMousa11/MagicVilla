
using MagicVilla.Core.DTO;
using MagicVilla.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValliaAPIContoller : ControllerBase
    { private readonly IVillaService _villaService;
        public ValliaAPIContoller(IVillaService villaService)
        {
            _villaService = villaService;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<VillaResponse>>> GetVillas()
        {
            var villas = await _villaService.GetAllVillas();
            return Ok(villas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaResponse>> GetVillasbyId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _villaService.GetVillabyId(id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaResponse>> CreateVilla([FromBody] VillaAddRequest villaAddRequest)
        {
            if (villaAddRequest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var villa = await _villaService.AddVilla(villaAddRequest);
            return CreatedAtRoute("GetVilla", villaAddRequest);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<VillaResponse>> UpdateVilla(int id, [FromBody] VillaUpdateRequest villaUpdateRequest)
        {
            if (villaUpdateRequest == null || id == 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var villa = await _villaService.UpdateVilla(id, villaUpdateRequest);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var isSuccess = await _villaService.DeleteVila(id);
            if(!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
