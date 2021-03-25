using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoBookApi.Models
{
//Order information submitted by customers:
// OrderID
// ProductType and Quantity. // Product type can be 1 of type photoBook, calendar, canvas, cards, mug

// Order information retrievable from the Web API by OrderID:
// ProductType with quantity
// RequiredBinWidth in millimeters (mm)
    public class Order
    {
        public string OrderId { get; set; }
        public double RequiredBinWidth {get; set;}
        public ICollection<Item> Items {get; set;}

        public static explicit operator Order(Task<Order> v)
        {
            throw new NotImplementedException();
        }
    }
}