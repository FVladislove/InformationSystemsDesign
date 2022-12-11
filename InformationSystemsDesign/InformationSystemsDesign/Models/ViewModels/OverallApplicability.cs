namespace InformationSystemsDesign.Models.ViewModels
{
    public class OverallApplicability
    {
        public string ComponentCode { get; set; } = null!;

        public string ComponentName { get; set; } = null!;

        public int Quanity { get; set; } = default!;

        public string EntryLevel { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            if (!(obj is OverallApplicability))
            {
                return false;
            }

            return Equals((OverallApplicability)obj);
        }

        public bool Equals(OverallApplicability other)
        {
            if (ComponentCode == other.ComponentCode
                && ComponentName == other.ComponentName
                && Quanity == other.Quanity
                && EntryLevel == other.EntryLevel)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(ComponentCode, ComponentName, Quanity, EntryLevel).GetHashCode();
        }
    }
}
