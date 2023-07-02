using BensModManager.Api.Services.ModService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace BensModManager.Api.Controllers
{
    [Tags("Mods")]
    [Route("api/[controller]")]
    [ApiController]
    public class ModController : ControllerBase
    {
        private readonly IModService _modService;

        public ModController(IModService modService)
        {
            _modService = modService;
        }
        [Tags("Get")]
        [HttpGet]
        public async Task<ActionResult<List<Mod>>> GetAllMods()
        {
            return await _modService.GetAllMods();    
        }
        [Tags("Get")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Mod>> GetSingleMod(int id)
        {
            var result = await _modService.GetSingleMod(id);
            if (result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }

        [Tags("Create")]
        [HttpPost]
        public async Task<ActionResult<List<Mod>>> AddMod(Mod mod)
        {
            var result = await _modService.AddMod(mod);
            return Ok(result);
        }

        [Tags("Update")]
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Mod>>> UpdateMod(int id, Mod request)
        {
            var result = await _modService.UpdateMod(id, request);
            if (result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }

        [Tags("Delete")]
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
