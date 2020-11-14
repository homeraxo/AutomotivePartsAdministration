using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Partycontactrelationship
    {
        public int PartyContactRelationshipId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int PartyId { get; set; }
        public int ContactTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Contacttype ContactType { get; set; }
        public virtual Party Party { get; set; }
    }
}
