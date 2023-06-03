using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Queries.GetAllPCRanks
{
    public class GetAllPCRanksQuery : IRequest<IEnumerable<PCRanksDto>>
    {

    }
}
