using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class DovTO
    {
        [Key]
        [Required]
        public string CdTO { get; set; } = null!;

        [Required]
        [NotNull]
        public string NmTO { get; set; } = null!;

        public virtual ICollection<PTRN> PTRNCdTONavigations { get; set; } = new List<PTRN>();

        public virtual ICollection<TO_PF> TO_PFCdTONavigations { get; set; } = new List<TO_PF>();
    }
}