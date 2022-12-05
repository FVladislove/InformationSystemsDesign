using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class GLPR
    {
        [Key]
        [Required]
        [NotNull]
        public string CdPr { get; set; }

        [Required]
        [NotNull]
        public string NmPr { get; set; }

        [Required]
        public int CdTp { get; set; }
    }
}
