using System;
using System.Collections.Generic;

namespace InformationSystemsDesign.Models;

public partial class StrRozv
{
    public string CdVyr { get; set; } = null!;

    public string CdSb { get; set; } = null!;

    public string CdKp { get; set; } = null!;

    public int QtyKp { get; set; }

    public int RivNb { get; set; }

    public string RivGrf { get; set; } = null!;
}
