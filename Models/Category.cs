using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProdnCategories.Models
{
    public class Category
    {
        [Key]
        public int category_id {get;set;}
        [Required]
        [Display(Name="Name")]
        public string name {get;set;}
        public DateTime created_at{get;set;}
        public DateTime updated_at{get;set;}

        public List<Association> Associations {get;set;}


    }
}