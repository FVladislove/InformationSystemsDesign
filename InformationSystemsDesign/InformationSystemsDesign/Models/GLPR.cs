using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class GLPR
    {
        [Key]
        [Required]
        [NotNull]
        public string CdPr { get; set; } = "";

        [Required]
        [NotNull]
        public string NmPr { get; set; } = "";

        [Required]
        public int CdTp { get; set; }

        public virtual TypePr CdTpNavigation { get; set; } = null!;

        public virtual ICollection<Spec> SpecCdKpNavigations { get; set; } = new List<Spec>();
        public virtual ICollection<Spec> SpecCdSbNavigations { get; set; } = new List<Spec>();

        public virtual ICollection<StrRozv> StrRozvCdVyrNavigations { get; set; } = new List<StrRozv>();
        public virtual ICollection<StrRozv> StrRozvCdSbNavigations { get; set; } = new List<StrRozv>();
        public virtual ICollection<StrRozv> StrRozvCdKpNavigations { get; set; } = new List<StrRozv>();

        public virtual ICollection<SumRozv> SumRozvCdVyrNavigations { get; set;} = new List<SumRozv>();
        public virtual ICollection<SumRozv> SumRozvCdKpNavigations { get; set;} = new List<SumRozv>();
    }
}
