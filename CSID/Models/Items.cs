using System;
using System.Collections.Generic;

namespace CSID.Models
{
    public partial class Items
    {
        public Items()
        {
            UserIdItemsId = new HashSet<UserIdItemsId>();
        }

        public string ItemId { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? WholesalePrice { get; set; }
        public decimal? CustomerDiscountPrice { get; set; }
        public int? Inventory { get; set; }

        public virtual ICollection<UserIdItemsId> UserIdItemsId { get; set; }
    }
}
