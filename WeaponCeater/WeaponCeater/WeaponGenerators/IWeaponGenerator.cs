namespace WeaponCeater
{
    /// <summary>
    /// Generator of weapon
    /// </summary>
    public interface IWeaponGenerator
    {
        /// <summary>
        /// Create weapon
        /// </summary>
        /// <param name="legendaryWeaponChance">Chance to create legendary weapon</param>
        /// <returns>Generated weapon</returns>
        IWeapon Generate(int legendaryWeaponChance);
    }
}