using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Partyperson
    {
        public Partyperson()
        {
            Party = new HashSet<Party>();
        }

        public int PartyPersonId { get; set; }
        public string Name { get; set; }
        public string MaternalSurname { get; set; }
        public string PaternalSurname { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Party> Party { get; set; }
    }
}
