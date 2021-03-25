using System;

namespace PhotoBookApi.Helper
{
    // This class will contain all the valid product types.
    // The idea is this will comme from cache, probably this will be a DB call when the services are loading
    // and will be available in a cache system, like Redis.
    public class ProductType
    {

        // This enum will work for the Package Creation
        // The idea is on the DB there is a table with the maintenance of: Id and encoded_value
        // For this assigment we will handle it here.
        public enum ProductTypeEnum{       
            photoBook = 1, 
            calendar = 2,
            canvas = 3, 
            cards = 4, 
            
            mug = 5
            }

        #pragma warning disable 0162 // Unreachable code detected 0162
        public double PackageWidth(ProductTypeEnum productType, int quantity)
        {
            //a mug has 1 detail: it can be stacked onto each other (up to 4 in a stack)
            var mugStacks = quantity / 4;
            var remainingMugs = quantity % 2 > 0 ? 1 : 0;
            switch (productType)
            {
                case ProductTypeEnum.photoBook:
                    return 19 * quantity; // 1 photoBook consumes 19 mm of package width
                    break;
                case ProductTypeEnum.calendar:
                    return 10 * quantity; // 1 calendar — 10 mm of package width
                    break;
                case ProductTypeEnum.canvas:
                    return 16 * quantity;// 1 canvas — 16 mm
                    break;
                case ProductTypeEnum.cards:
                    return 4.7 * quantity; //1 set of greeting cards — 4.7 mm
                    break;
                case ProductTypeEnum.mug:
                    return 94 * (mugStacks + remainingMugs); //1 mug — 94 mm
                    break;
                default:
                    return 0 * quantity;
                    break;
            }
        }
    }

}