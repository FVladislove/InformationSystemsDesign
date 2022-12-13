using System.ComponentModel;

namespace InformationSystemsDesign.Models.ViewModels
{
    public class MaterialStandard
    {
        [DisplayName("CdVyr")]
        public string ProductCode { get; set; } = null!;

        [DisplayName("NmPr")]
        public string StaffName { get; set; } = null!;

        [DisplayName("CdMt")]
        public string MaterialCode { get; set; } = null!;

        [DisplayName("CommMt")]
        public float GeneralNeedForMaterial { get; set; }
    }
}
