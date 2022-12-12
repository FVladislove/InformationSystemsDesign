using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class DovMt
    {
        [Key]
        [Required]
        [NotNull]
        public string CdMt { get; set; } = null!;


        [Required]
        [NotNull]
        public string NmMt { get; set; } = null!;

        public virtual ICollection<ZastMt> ZastMtCdMtNavigations { get; set; } = new List<ZastMt>();
    }
}
