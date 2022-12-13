using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class PTRN
    {
        [Required]
        [NotNull]
        public string CdPr { get; set; } = null!;

        [Required]
        [NotNull]
        public string CdTO { get; set; } = null!;

        [Required]
        [NotNull]
        public string NbTO { get; set; } = null!;

        [Required]
        [NotNull]
        public float Godin { get; set; }

        public virtual GLPR CdPrNavigation { get; set; } = null!;
        public virtual DovTO CdTONavigation { get; set; } = null!;
    }
}
