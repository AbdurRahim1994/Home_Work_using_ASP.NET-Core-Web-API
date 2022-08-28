using System;
using System.Collections.Generic;

namespace Home_Work.Models.Data.Entity
{
    public partial class TblPurchaseDetail
    {
        public long IntPurchaseDetailsId { get; set; }
        public long IntPurchaseId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumQuantity { get; set; }
        public decimal NumUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
