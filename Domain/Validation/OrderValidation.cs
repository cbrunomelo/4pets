using Domain.Entitys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    internal class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(x => x.Client)
                .NotNull().WithMessage("Client is required");

            RuleFor(x => x.Items)
                .NotNull().WithMessage("Items is required")
                .Must(x => x.Count > 0).WithMessage("Items is required");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("Total must be greater than 0");
        }

    }
}
