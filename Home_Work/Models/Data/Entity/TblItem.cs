using System;
using System.Collections.Generic;

namespace Home_Work.Models.Data.Entity
{
    public partial class TblItem
    {
        public long IntItemId { get; set; }
        public string StrItemName { get; set; } = null!;
        public decimal NumStockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
