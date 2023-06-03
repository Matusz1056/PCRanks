using AutoMapper;
using MediatR;
using PCRanks.Application.ApplicationUser;
using PCRanks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Commands.CreatePCRanks
{
    public class CreatePCRanksCommandHandler : IRequestHandler<CreatePCRanksCommand>
    {
        private readonly IPCRanksRepository _PCRanksRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreatePCRanksCommandHandler(IPCRanksRepository pCRanksRepository, IMapper mapper, IUserContext userContext) 
        {
        _PCRanksRepository = pCRanksRepository;
            _mapper = mapper;
            _userContext = userContext;
        }  
        public async Task<Unit> Handle(CreatePCRanksCommand request, CancellationToken cancellationToken)
        {
            var pCRanks = _mapper.Map<Domain.Entities.PCRanks>(request);
            pCRanks.EncodeName();

            pCRanks.CreatedById = _userContext.GetCurrentUser().Id;

            await _PCRanksRepository.Create(pCRanks);
            return Unit.Value;
        }
    }
}
