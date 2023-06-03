using AutoMapper;
using MediatR;
using PCRanks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Queries.GetPCRanksByEncodedName
{
    public class GetPCRanksByEncodedNameQueryHandler : IRequestHandler<GetPCRanksByEncodedNameQuery, PCRanksDto>
    {
        private readonly IPCRanksRepository _PCRanksRepository;
        private readonly IMapper _mapper;
        public GetPCRanksByEncodedNameQueryHandler(IPCRanksRepository pCRanksRepository, IMapper mapper)  
        { 
        _PCRanksRepository = pCRanksRepository;
            _mapper = mapper;
        }    
        public async Task<PCRanksDto> Handle(GetPCRanksByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var PCRanks = await _PCRanksRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<PCRanksDto>(PCRanks);
            return dto;
        }
    }
}
