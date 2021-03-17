using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLibrary.BL
{
   public class Inventory
    {
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }
       
    
}
}
