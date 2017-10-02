using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WeaponCeater
{
    /// <summary>
    /// Storage of weapons
    /// </summary>
    public class Inventory : IEnumerable<IWeapon>
    {
        /// <summary>
        /// Max count of weapons to store
        /// </summary>
        public const int MaxWeaponCount = 6;

        private readonly List<IWeapon> weapons;

        /// <summary>
        /// Initialize inventory
        /// </summary>
        public Inventory()
        {
            weapons = new List<IWeapon>();
        }

        /// <summary>
        /// Returns true, when inventory is full
        /// </summary>
        /// <returns>True, when inventory is full</returns>
        public bool IsFull()
        {
            return weapons.Count() >= MaxWeaponCount;
        }
        
        /// <summary>
        /// Add weapon to inventory
        /// </summary>
        /// <param name="weapon">Added weapon</param>
        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        /// <summary>
        /// Remove weapon from inventory
        /// </summary>
        /// <param name="replacedWeaponIndex">Index of removed weapon</param>
        public void RemoveAt(int replacedWeaponIndex)
        {
            weapons.RemoveAt(replacedWeaponIndex);
        }

        /// <summary>
        /// Returns total cost of all weapons
        /// </summary>
        /// <returns>Total cost of all weapons</returns>
        public int GetTotalCost()
        {
            return weapons.Sum(weapon => weapon.Stats.Value);
        }

        /// <summary>
        /// Returns enumerator of weapon collection
        /// </summary>
        /// <returns>Enumerator of weapon collection</returns>
        public IEnumerator<IWeapon> GetEnumerator()
        {
            return weapons.GetEnumerator();
        }

        /// <summary>
        /// Returns enumerator of weapon collection
        /// </summary>
        /// <returns>Enumerator of weapon collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}