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
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (!(obj is OverallApplicability))
            {
                return false;
            }

            return Equals((OverallApplicability)obj);
        }

        public bool Equals(OverallApplicability other)
        {
            return ComponentCode == other.ComponentCode
                && ComponentName == other.ComponentName
                && Quanity == other.Quanity
                && EntryLevel == other.EntryLevel;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ComponentCode, ComponentName, Quanity, EntryLevel);
        }
    }
}
