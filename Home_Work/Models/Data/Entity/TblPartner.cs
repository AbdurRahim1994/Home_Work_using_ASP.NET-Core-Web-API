using System;
using System.Collections.Generic;

namespace Home_Work.Models.Data.Entity
{
    public partial class TblPartner
    {
        public long IntPartnerId { get; set; }
        public string StrPartnerName { get; set; } = null!;
        public long IntPartnerTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
