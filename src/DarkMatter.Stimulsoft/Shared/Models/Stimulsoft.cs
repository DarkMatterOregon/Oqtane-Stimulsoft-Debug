using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace DarkMatter.Stimulsoft.Models
{
    [Table("DarkMatterStimulsoft")]
    public class Stimulsoft : IAuditable
    {
        [Key]
        public int StimulsoftId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
