using BensModManager.Api.Services.ModService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;
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
        [HttpGet("/mod/all-mods")]
        [SwaggerOperation(summary: "Gets a list of all the current mods")]
        public async Task<ActionResult<List<Mod>>> GetAllMods()
        {
            return await _modService.GetAllMods();    
        }

        [HttpGet("/mod/{id}")]
        [SwaggerOperation(summary: "Get a mod via it's ID.")]
        public async Task<ActionResult<Mod>> GetSingleMod(int id)
        {
            var result = await _modService.GetSingleMod(id);
            if (result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }


        [HttpGet("/mod")]
        [SwaggerOperation(summary: "Search for mods by their name, type or whether they are obsolete.")]
        public async Task<ActionResult<IEnumerable<Mod>>> Search(string modName, string modType, bool obsolete)
        {
            var result = await _modService.Search(modName, modType, obsolete);

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No results found.");
            }
        }

        [HttpPost("/mod")]
        [SwaggerOperation(summary: "Add a mod.")]
        public async Task<ActionResult<List<Mod>>> AddMod(Mod mod)
        {
            var result = await _modService.AddMod(mod);
            return Ok(result);
        }

        [HttpPut("/mod/{id}")]
        [SwaggerOperation(summary: "Update a mod via it's ID.")]

        public async Task<ActionResult<List<Mod>>> UpdateMod(int id, Mod request)
        {
            var result = await _modService.UpdateMod(id, request);
            if (result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }

        [HttpDelete("/mod/{id}")]
        [SwaggerOperation(summary: "Delet a mod via it's ID.")]
        public async Task<ActionResult<List<Mod>>> DeleteMod(int id)
        {
            var result = await _modService.DeleteMod(id);
            if(result is null)
                return NotFound("This Mod (" + id + ") doesn't exist.");
            return Ok(result);
        }
    }
}
