using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class DovPrf
    {
        [Key]
        [Required]
        [NotNull]
        public float CdPf { get; set; }

        [Required]
        [NotNull]
        public string NmPf { get; set; } = null!;

        public virtual ICollection<TO_PF> TO_PFCdPfNavigations { get; set; } = new List<TO_PF>();
    }
}
