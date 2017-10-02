namespace WeaponCeater
{
    /// <summary>
    /// Weapon data
    /// </summary>
    public class WeaponStatistics
    {
        public const string UndefinedImageName = "undefined";

        public string Name { get; set; }
        public int Fightspeed { get; set; }
        public int Damage { get; set; }
        public int CriticalHitChance { get; set; }
        public int Value { get; set; }
        public string ImageName { get; set; }
        public string Creator { get; set; }
        public int Level { get; set; }

        /// <summary>
        /// Combine weapon statistics to another
        /// </summary>
        /// <param name="other">Weapon statistics for combine</param>
        /// <returns>Combined weapon statistics</returns>
        public WeaponStatistics Combine(WeaponStatistics other)
        {
            return new WeaponStatistics
            {
                Name = CombineNames(Name, other.Name),
                Fightspeed = CombineIntValues(Fightspeed, other.Fightspeed),
                Damage = CombineIntValues(Damage, other.Damage),
                CriticalHitChance = CombineIntValues(CriticalHitChance, other.CriticalHitChance),
                Value = CombineIntValues(Value, other.Value),
                ImageName = UndefinedImageName,
                Creator = CombineCreators(Creator, other.Creator),
                Level = CombineIntValues(Level, other.Level),
            };
        }

        private static int CombineIntValues(int first, int second)
        {
            return (first + second) / 2;
        }

        private static string CombineCreators(string first, string second)
        {
            return string.Format("{0}/{1}", first, second);
        }

        private static string CombineNames(string first, string second)
        {
            return string.Format("{0} {1}", first, second);
        }

        /// <summary>
        /// Returns information about weapon data
        /// </summary>
        /// <returns>Information about weapon data</returns>
        public override string ToString()
        {
            return string.Format(
                    "Name: {0}, Creator: {1}, Level: {2}, Damage: {3}, Fightspeed: {4} hit per s, CriticalHitChance: {5}%, Value: {6}",
                    Name,
                    Creator,
                    Level,
                    Damage,
                    Fightspeed,
                    CriticalHitChance,
                    Value);
        }
    }
}
