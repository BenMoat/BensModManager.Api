using System.Reflection;

namespace BensModManager.Api.Services.ModService
{
    public interface IModService
    {
        Task<List<Mod>> GetAllMods();
        Task<Mod> GetSingleMod(int id);
        Task<IEnumerable<Mod>> Search(string modName, string modType, bool obsolete);
        Task<List<Mod>> AddMod(Mod mod);
        Task<List<Mod>> UpdateMod(int id, Mod request);
        Task<List<Mod>> DeleteMod(int id);
    }
}
