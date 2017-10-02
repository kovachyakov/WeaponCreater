using System.Drawing;

namespace WeaponCeater
{
    /// <summary>
    /// Base interface for game item
    /// </summary>
    public interface IWeaponItem
    {
        /// <summary>
        /// Weapon statistsics
        /// </summary>
        WeaponStatistics Stats { get; set; }
        /// <summary>
        /// Weapon skin
        /// </summary>
        Bitmap Picture { get; set; }
    }

    /// <summary>
    /// Base interface for weapon
    /// </summary>
    public interface IWeapon : IWeaponItem { }

    /// <summary>
    /// Base interface for weapon's part
    /// </summary>
    public interface IWeaponPart : IWeaponItem { }

    /// <summary>
    /// Base implementations of sword weapon part
    /// </summary>
    public abstract class BaseSwordPart : IWeaponPart
    {
        /// <summary>
        /// Sword statistics
        /// </summary>
        public WeaponStatistics Stats { get; set; }
        /// <summary>
        /// Sword skin
        /// </summary>
        public Bitmap Picture { get; set; }
    }

    /// <summary>
    /// Sword blade
    /// </summary>
    public class SwordBlade : BaseSwordPart { }

    /// <summary>
    /// Sword handle
    /// </summary>
    public class SwordHandle : BaseSwordPart { }

    /// <summary>
    /// Base interface of sword
    /// </summary>
    public interface ISword : IWeapon { }

    /// <summary>
    /// Base implementaion of sword
    /// </summary>
    public abstract class BaseSword : ISword
    {
        /// <summary>
        /// Sword statistics
        /// </summary>
        public WeaponStatistics Stats { get; set; }
        /// <summary>
        /// Sword skin
        /// </summary>
        public Bitmap Picture { get; set; }

        /// <summary>
        /// Returns information about sword
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Stats.ToString();
        }
    }

    /// <summary>
    /// Simple sword
    /// </summary>
    public class Sword : BaseSword { }

    /// <summary>
    /// Legendary sword
    /// </summary>
    public class LegendarySword : BaseSword { }
}
