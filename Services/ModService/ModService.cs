using BensModManager.Api.Data;

namespace BensModManager.Api.Services.ModService
{
    public class ModService : IModService
    {
        private readonly DataContext _context;

        public ModService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Mod>> GetAllMods()
        {
            var mods = await _context.Mods.ToListAsync();
            return mods;
        }

        public async Task<Mod?> GetSingleMod(int id)
        {
            var mod = await _context.Mods.FindAsync(id);
            if (mod is null)
                return null;

            return mod;
        }

        public async Task<List<Mod>> AddMod(Mod mod)
        {
            _context.Mods.Add(mod);
            await _context.SaveChangesAsync();
            return await _context.Mods.ToListAsync();
        }

        public async Task<List<Mod>?> UpdateMod(int id, Mod request)
        {
            var mod = await _context.Mods.FindAsync(id);
            if (mod is null)
                return null;

            mod.ModName = request.ModName;
            mod.Price = request.Price;
            mod.ModType = request.ModType;
            mod.Obsolete = request.Obsolete;
            mod.Notes = request.Notes;
            mod.FileName = request.FileName;
            mod.FileType = request.FileType;
            mod.FileExtension = request.FileExtension;
            mod.FilePath = request.FilePath;

            await _context.SaveChangesAsync();

            return await _context.Mods.ToListAsync();
        }

        public async Task<List<Mod>?> DeleteMod(int id)
        {
            var mod = await _context.Mods.FindAsync(id);
            if (mod is null)
                return null;

            _context.Mods.Remove(mod);
            await _context.SaveChangesAsync();

            return await _context.Mods.ToListAsync();

        }
    }
}
