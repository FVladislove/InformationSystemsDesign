using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class Spec : IValidatableObject
    {
        [Required]
        [NotNull]
        public string CdSb { get; set; } = null!;

        [Required]
        [NotNull]
        public string CdKp { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        public int QtyKp { get; set; }

        public virtual GLPR CdKpNavigation { get; set; } = null!;
        public virtual GLPR CdSbNavigation { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(CdSb == CdKp)
            {
                yield return new ValidationResult(
                    "CdSb and CdKp must have a different value");
            }
        }
    }
}
