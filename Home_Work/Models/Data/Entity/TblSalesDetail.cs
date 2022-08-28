using System;
using System.Collections.Generic;

namespace Home_Work.Models.Data.Entity
{
    public partial class TblSalesDetail
    {
        public long IntSalesDetailsId { get; set; }
        public long IntSalesId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumQuantity { get; set; }
        public decimal NumUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
