using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Domain.Interfaces
{
    public interface IPCRanksRepository
    {
        Task Create(Domain.Entities.PCRanks pCRanks);
        Task<Domain.Entities.PCRanks?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.PCRanks>> GetAll();
        Task<Domain.Entities.PCRanks> GetByEncodedName(string encodedName);
        Task Comit();
    }
}
