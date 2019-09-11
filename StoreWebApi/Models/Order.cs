using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string StatusName { get; set; }      
    }
}