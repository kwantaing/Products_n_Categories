using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdnCategories.Models
{
    public class Product
    {
        [Key]
        public int product_id {get;set;}
        [Required]
        [Display(Name="Name")]
        public string name {get;set;}
        [Required]
        [Display(Name="Description")]
        public string description {get;set;}
        
        [Required(ErrorMessage="Please enter a valid price.")]
        [DataType(DataType.Currency,ErrorMessage="Please enter a valid price.")]
        [Display(Name="Price")]
        public decimal price {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}

        //Navigation Properties

        public List<Association> Associations {get;set;}
    }
}