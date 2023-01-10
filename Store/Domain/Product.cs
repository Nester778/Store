using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ProviderName")]
        public string ProviderName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "CreationData")]
        public DateTime CreationData { get; set; }
        [Display(Name = "ModificationData")]
        public DateTime ModificationData { get; set; }
        [Display(Name = "Manager")]
        public string Manager { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Amount")]
        public int Amount { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        
    }
}
