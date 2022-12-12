using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class SumRozv
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [NotNull]
        public string CdVyr { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string CdKp { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public int SumKp { get; set; }

        [Required]
        [NotNull]
        public int MinRv { get; set; }

        [Required]
        [NotNull]
        public int CdTp { get; set; }

        public virtual GLPR CdVyrNavigation { get; set; } = null!;
        public virtual GLPR CdKpNavigation { get; set; } = null!;
        public virtual TypePr CdTpNavigation { get; set; } = null!;
    }
}
