using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks.Commands.EditPCRanks
{
    public class EditPCRanksCommandValidator : AbstractValidator<EditPCRanksCommand>
    {
        public EditPCRanksCommandValidator() 
        {
            RuleFor(c => c.GameName)
     .NotEmpty().WithMessage("Please enter game name");

            RuleFor(c => c.GameResolution)
                .NotEmpty().WithMessage("Please enter game resolution")
                .MinimumLength(7).WithMessage("Resolution shoul have atleast 7 characters")
                .MaximumLength(9).WithMessage("Resolution shoul have maximum 9 characters");

            RuleFor(c => c.GameSettings)
                 .NotEmpty().WithMessage("Please enter game settings");

            RuleFor(c => c.Fps)
                 .NotEmpty().WithMessage("Please enter fps score");

            RuleFor(c => c.Cpu)
                 .NotEmpty().WithMessage("Please enter cpu model");

            RuleFor(c => c.Gpu)
                 .NotEmpty().WithMessage("Please enter gpu model");

            RuleFor(c => c.Mobo)
                 .NotEmpty().WithMessage("Please enter motheboard model");

            RuleFor(c => c.Psu)
                 .NotEmpty().WithMessage("Please enter psu model");
        }
    }
}
