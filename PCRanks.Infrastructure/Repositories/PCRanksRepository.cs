using Microsoft.EntityFrameworkCore;
using PCRanks.Domain.Interfaces;
using PCRanks.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Infrastructure.Repositories
{
    internal class PCRanksRepository : IPCRanksRepository
    {
        private readonly PCRanksDbContext _dbContext;
        public PCRanksRepository(PCRanksDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task Comit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.PCRanks pCRanks)
        {
            _dbContext.Add(pCRanks);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.PCRanks>> GetAll()
        => await _dbContext.PCRanks.ToListAsync();

        public async Task<Domain.Entities.PCRanks> GetByEncodedName(string encodedName)
        => await _dbContext.PCRanks.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.PCRanks?> GetByName(string name)
        => _dbContext.PCRanks.FirstOrDefaultAsync(cw => cw.UserName == name);
    }
}
