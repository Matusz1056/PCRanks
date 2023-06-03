using MediatR;
using PCRanks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Commands.EditPCRanks
{
    internal class EditPCRanksCommandHandler : IRequestHandler<EditPCRanksCommand>
    {
        private readonly IPCRanksRepository _repository;
        public EditPCRanksCommandHandler(IPCRanksRepository repository)
        {
        _repository = repository;
        }
        public async Task<Unit> Handle(EditPCRanksCommand request, CancellationToken cancellationToken)
        {
            var PCRanks = await _repository.GetByEncodedName(request.EncodedName!);
            PCRanks.GameName = request.GameName;
            PCRanks.GameResolution = request.GameResolution;
            PCRanks.Fps = request.Fps;
            PCRanks.PCSpecs.Cpu = request.Cpu;
            PCRanks.PCSpecs.Gpu = request.Gpu;
            PCRanks.PCSpecs.Mobo = request.Mobo;
            PCRanks.PCSpecs.Psu = request.Psu;

            await _repository.Comit();
            return Unit.Value;
        }
    }
}
