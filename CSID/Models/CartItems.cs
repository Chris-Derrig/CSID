using System;
using System.Collections.Generic;

namespace CSID.Models
{
    public partial class CartItems
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal? CustomerDiscountPrice { get; set; }
    }
}
