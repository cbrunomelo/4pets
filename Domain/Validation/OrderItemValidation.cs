using Domain.Entitys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    internal class OrderItemValidation : AbstractValidator<OrderItem>
    {
        public OrderItemValidation()
        {
            RuleFor(x => x.Product)
                .NotNull().WithMessage("Product is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("Total must be greater than 0");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage($"Product is required");
        }
    }
}
