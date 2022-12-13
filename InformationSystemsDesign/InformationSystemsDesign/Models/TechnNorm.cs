using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class TechnNorm
    {
        // must be from SumRozv table
        [Required]
        [NotNull]
        public string CdVyr { get; set; } = null!;

        // must be from PTRN table
        [Required]
        [NotNull]
        public string CdTO { get; set; } = null!;

        // must be from DovTO table
        [Required]
        [NotNull]
        public string NmTO { get; set; } = null!;

        [Required]
        [NotNull]
        public float SumGodin { get; set; }
    }
}
