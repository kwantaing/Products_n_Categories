using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProdnCategories.Models
{
    public class Association
    {
        [Key]
        public int association_id {get;set;}
        public int product_id {get;set;}
        public int category_id {get;set;}

        //Navigation Properties
        public Category category{get;set;}
        public Product product{get;set;}

    }
}