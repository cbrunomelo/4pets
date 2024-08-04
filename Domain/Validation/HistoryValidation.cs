using Domain.Entitys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    public class HistoryValidation : AbstractValidator<History>
    {
        public HistoryValidation()
        {
            RuleFor(x => x.Action)
                .NotEmpty()
                .WithMessage("Action is required");

            RuleFor(x => x.entityName)
                .NotEmpty()
                .WithMessage("EntityName is required")
                .MaximumLength(100)
                .WithMessage("EntityName must be less than 100 characters");

            RuleFor(x => x.EntityId)
                .NotEmpty()
                .WithMessage("EntityId is required");

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required");
        }

    }
}
