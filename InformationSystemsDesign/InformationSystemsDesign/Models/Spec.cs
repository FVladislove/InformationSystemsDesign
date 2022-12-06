using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models
{
    public class Spec : IValidatableObject
    {
        [Required]
        [NotNull]
        public string CdSb { get; set; }

        [Required]
        [NotNull]
        public string CdKp { get; set; }

        [ForeignKey("CdSb")]
        public virtual GLPR? GLPR_CdSb { get; set; }

        [ForeignKey("CdKp")]
        public virtual GLPR? GLPR_CdKp { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QtyKp { get; set; }

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
