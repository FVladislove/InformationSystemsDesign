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

        public virtual ICollection<GLPR> GLPRNavigations { get;} = new List<GLPR>();
        public virtual ICollection<SumRozv> SumRozvNavigations { get; set; } = new List<SumRozv>();
    }
}