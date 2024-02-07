using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class ColorsRepository
    {
        private readonly EntityContext _dbContext;

        public ColorsRepository(EntityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> GetAllColors()
        {
            return await _dbContext.Colors.Select(x => x.Value).ToListAsync();
        }

        public async Task AddColor(Color color)
        {
            _dbContext.Colors.Add(color);
            await _dbContext.SaveChangesAsync();
        }
    }
}
