using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Queries.GetPCRanksByEncodedName
{
   public class GetPCRanksByEncodedNameQuery : IRequest<PCRanksDto>
    {
        public string EncodedName { get; set; }
        public GetPCRanksByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
