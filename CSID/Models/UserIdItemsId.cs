using System;
using System.Collections.Generic;

namespace CSID.Models
{
    public partial class UserIdItemsId
    {
        public string UserIdItemId { get; set; }
        public string UserId { get; set; }
        public string ItemsId { get; set; }

        public virtual Items Items { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
