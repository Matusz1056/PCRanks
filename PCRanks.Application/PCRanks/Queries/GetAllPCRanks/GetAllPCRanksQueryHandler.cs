using AutoMapper;
using MediatR;
using PCRanks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Queries.GetAllPCRanks
{
    internal class GetAllPCRanksQueryHandler : IRequestHandler<GetAllPCRanksQuery, IEnumerable<PCRanksDto>>
    {
        private readonly IPCRanksRepository _PCRanksRepository;
        private readonly IMapper _mapper;
        public GetAllPCRanksQueryHandler(IPCRanksRepository pCRanksRepository, IMapper mapper)
        {
            _PCRanksRepository = pCRanksRepository;
            _mapper = mapper;
        }  
        public async Task<IEnumerable<PCRanksDto>> Handle(GetAllPCRanksQuery request, CancellationToken cancellationToken)
        {
            var PCRanks = await _PCRanksRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<PCRanksDto>>(PCRanks);
            return dtos;
        }
    }
}
