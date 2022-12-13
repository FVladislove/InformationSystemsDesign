using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class TO_PF
    {
        [Key]
        [Required]
        [NotNull]
        public string CdTO { get; set; } = null!;

        [Required]
        [NotNull]
        public float CdPf { get; set; }

        public virtual DovTO CdTONAvigation { get; set; } = null!;
        public virtual DovPrf CdPfNavigations { get; set; } = null!;
    }
}
