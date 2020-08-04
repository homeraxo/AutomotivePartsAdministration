using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Partyaddress
    {
        public Partyaddress()
        {
            Party = new HashSet<Party>();
        }

        public int PartyAddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string NumberOutside { get; set; }
        public string NumberInside { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Party> Party { get; set; }
    }
}
