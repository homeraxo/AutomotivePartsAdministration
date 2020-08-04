﻿using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Contacttype
    {
        public Contacttype()
        {
            Partycontactrelationship = new HashSet<Partycontactrelationship>();
        }

        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Partycontactrelationship> Partycontactrelationship { get; set; }
    }
}
