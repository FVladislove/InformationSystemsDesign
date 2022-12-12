using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class ZastMt
    {
        [Required]
        [NotNull]
        public string CdKp { get; set; } = null!;

        [Required]
        [NotNull]
        public string CdMt { get; set; } = null!;

        [Required]
        [NotNull]
        public string OdVym { get; set; } = null!;

        [Required]
        [NotNull]
        public float QtyMt { get; set; }

        public virtual GLPR CdKpNavigation { get; set; } = null!;
        public virtual DovMt CdMtNavigation { get; set; } = null!;
    }
}
