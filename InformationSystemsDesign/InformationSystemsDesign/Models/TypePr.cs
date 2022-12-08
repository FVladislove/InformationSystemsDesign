using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class TypePr{
        [Key]
        [Required]
        public int CdTp { get; set; }

        [Required]
        [NotNull]
        public string NmTp { get; set; } = null!;

        public virtual ICollection<GLPR> GLPRs { get;} = new List<GLPR>();
    }
}