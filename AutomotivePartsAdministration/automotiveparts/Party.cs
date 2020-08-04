using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Party
    {
        public Party()
        {
            Partycontactrelationship = new HashSet<Partycontactrelationship>();
            Sale = new HashSet<Sale>();
        }

        public int PartyId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? PartyPersonId { get; set; }
        public int? PartyOrganizationId { get; set; }
        public int PartyTypeId { get; set; }
        public int PartyAddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Partyaddress PartyAddress { get; set; }
        public virtual Partyorganization PartyOrganization { get; set; }
        public virtual Partyperson PartyPerson { get; set; }
        public virtual Partytype PartyType { get; set; }
        public virtual ICollection<Partycontactrelationship> Partycontactrelationship { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
