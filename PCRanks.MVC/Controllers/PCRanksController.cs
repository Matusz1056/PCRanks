using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using PCRanks.Application.PCRanks;
using PCRanks.Application.PCRanks.Commands.CreatePCRanks;
using PCRanks.Application.PCRanks.Queries.GetAllPCRanks;
using MediatR;
using PCRanks.Application.PCRanks.Queries.GetPCRanksByEncodedName;
using PCRanks.Application.PCRanks.Commands.EditPCRanks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace PCRanks.MVC.Controllers
{
    public class PCRanksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PCRanksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var PCRanks = await _mediator.Send(new GetAllPCRanksQuery());   
            return View(PCRanks);
        }

        [Route("PCRanks/{encodedName}/PCConfiguration")]
        public async Task<ActionResult> PCConfiguration(string encodedName)
        {
            var dto = await _mediator.Send(new GetPCRanksByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("PCRanks/{encodedName}/Edit")]
        public async Task<ActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetPCRanksByEncodedNameQuery(encodedName));
            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            EditPCRanksCommand model = _mapper.Map<EditPCRanksCommand>(dto);
            return View(model);
        }
        [HttpPost]
        [Route("PCRanks/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditPCRanksCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePCRanksCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        


    }
}
