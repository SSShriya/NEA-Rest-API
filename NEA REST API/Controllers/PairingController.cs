using Microsoft.AspNetCore.Mvc;
using NEA_Rest_API.Models;

namespace NEA_Rest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PairingController : ControllerBase
    {
        public class PairingData
        {
            public int U1 { get; set; }
            public int U2 { get; set; }
        }

        private readonly NeaContext _context;
        public PairingController(NeaContext context)
        {
            _context = context;
        }

        [HttpGet ("{uid}/{pid}")]
        public IActionResult GetPairings(int uid, int pid)
        {
            var pairings = _context.Pairings.Where(u => u.User2 == uid && u.PairingId>pid)
                .Select(p => new { p.User1, p.PairingId })
                .ToList();

            return Ok(pairings);
        
        }

        [HttpPost]
        public async Task<IActionResult> CreatePairing([FromBody] PairingData pairingData)
        {
            var pairing = new Pairing { User1 = pairingData.U1, User2 = pairingData.U2};
            _context.Pairings.Add(pairing);
            await _context.SaveChangesAsync();
            return Ok(pairing.PairingId);
        }

        //TAKE THIS OUT WHEN COPYING AND PASTING CODE
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
