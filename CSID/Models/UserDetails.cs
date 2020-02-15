using System;
using System.Collections.Generic;

namespace CSID.Models
{
    public partial class UserDetails
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; }
        public decimal? Funds { get; set; }
    }
}
