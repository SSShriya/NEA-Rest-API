using Microsoft.AspNetCore.Mvc;
using NEA_Rest_API.Models;

namespace NEA_Rest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PairingController : ControllerBase
    {
        private readonly NeaContext _context;
        public PairingController(NeaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePairing([FromBody] int u1, int u2)
        {
            var pairing = new Pairing { User1 = u1, User2 = u2};
            _context.Pairings.Add(pairing);
            await _context.SaveChangesAsync();
            return Ok(pairing.PairingId);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePairing([FromBody] int pid)
        {
            var pairing = new Pairing {PairingId = pid};
            _context.Pairings.Remove(pairing);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
