using PCRanks.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Infrastructure.Seeders
{
    public class PCRanksSeeder
    {
        private readonly PCRanksDbContext _dbContext;
        public PCRanksSeeder(PCRanksDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync()) 
            {
                if (!_dbContext.PCRanks.Any()) 
                {
                    var Matusz = new Domain.Entities.PCRanks()
                    {
                     UserName = "Matusz",
                     GameName = "The Witcher",
                     GameResolution = "1920x1080",
                     GameSettings = "Uber",
                     Fps = "88",
                     PCSpecs = new()
                     {
                         Cpu = "Ryzen 5 5600",
                         Gpu = "Rtx 4060TI",
                         Mobo = "Asrock B660",
                         Psu = "BeQuiet Darkpro 11"
                     }

    };
                    Matusz.EncodeName();

                    _dbContext.PCRanks.Add(Matusz);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
