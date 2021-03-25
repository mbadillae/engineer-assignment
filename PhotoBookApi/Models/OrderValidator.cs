using System;
using System.Collections.Generic;
using FluentValidation;
namespace PhotoBookApi.Models
{
    public class OrderValidator : AbstractValidator<Order>
    {
    public OrderValidator()  
        {  
            RuleFor(x => x.OrderId)  
                .NotEmpty().WithMessage("The Order Id cannot be blank.");  

            RuleForEach(x => x.Items).SetValidator(new ItemValidator()); 

            //Missing validaiton order id = order id
        } 

    }

    public class ItemValidator : AbstractValidator<Item> {
        public ItemValidator() 
        {
            RuleFor(x => x.ItemId).GreaterThan(0).WithMessage("The Item ID must be at greather than 0."); 
            RuleFor(x => x.OrderId)  
                .NotEmpty().WithMessage("The Order Id cannot be blank.");  

            RuleFor(x => x.ProductType)
                .IsInEnum().WithMessage("Product type not valid.");  
    
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be at greather than 0.");
        }
    }
}