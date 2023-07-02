using BensModManager.Api.Services.ModService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BensModManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModController : ControllerBase
    {
        private readonly IModService _modService;

        public ModController(IModService modService)
        {
            _modService = modService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mod>>> GetAllMods()
        {
            return await _modService.GetAllMods();    
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Mod>> GetSingleMod(int id)
        {
            var result = await _modService.GetSingleMod(id);
            if (result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Mod>>> AddMod(Mod mod)
        {
            var result = await _modService.AddMod(mod);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Mod>>> UpdateMod(int id, Mod request)
        {
            var result = await _modService.UpdateMod(id, request);
            if (result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Mod>>> DeleteMod(int id)
        {
            var result = await _modService.DeleteMod(id);
            if(result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }
    }
}
