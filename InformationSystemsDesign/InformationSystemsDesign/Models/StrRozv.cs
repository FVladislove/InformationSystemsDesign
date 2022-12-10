using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InformationSystemsDesign.Models;

public partial class StrRozv
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set;}

    [Required]
    [NotNull]
    public string CdVyr { get; set; } = null!;

    [Required]
    [NotNull]
    public string CdSb { get; set; } = null!;

    [Required]
    [NotNull]
    public string CdKp { get; set; } = null!;

    [Required]
    [NotNull]
    public int QtyKp { get; set; }

    [Required]
    [NotNull]
    public int RivNb { get; set; }

    [Required]
    [NotNull]
    public string RivGrf { get; set; } = null!;

    public virtual GLPR CdVyrNavigation { get; set; } = null!;
    public virtual GLPR CdSbNavigation { get; set; } = null!;
    public virtual GLPR CdKpNavigation { get; set; } = null!;
}
