using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryLibrary.Models
{
    public partial class TblItemInventory
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public byte? Quntity { get; set; }
    }
}
