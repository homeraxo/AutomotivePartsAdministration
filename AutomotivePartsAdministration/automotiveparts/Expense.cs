using System;
using System.Collections.Generic;

namespace AutomotivePartsAdministration.automotiveparts
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
