
using static PhotoBookApi.Helper.ProductType;

namespace PhotoBookApi.Models
{
//Order information submitted by customers:
// OrderID
// ProductType and Quantity. // Product type can be 1 of type photoBook, calendar, canvas, cards, mug

// Order information retrievable from the Web API by OrderID:
// ProductType with quantity
// RequiredBinWidth in millimeters (mm)
    public class Item
    {
        public int ItemId{get; set;}
        public string OrderId{get; set;}
        public ProductTypeEnum ProductType { get; set; }
        public int Quantity { get; set; }        
         // This is for entity framework in memory DB
        public Order Order{get; set;}
    }
}