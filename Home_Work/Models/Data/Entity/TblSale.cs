﻿using System;
using System.Collections.Generic;

namespace Home_Work.Models.Data.Entity
{
    public partial class TblSale
    {
        public long IntSalesId { get; set; }
        public long IntCustomerId { get; set; }
        public DateTime DteSalesDate { get; set; }
        public string? IsActive { get; set; }
    }
}