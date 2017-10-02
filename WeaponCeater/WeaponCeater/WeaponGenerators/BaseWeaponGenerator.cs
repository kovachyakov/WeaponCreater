using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeaponCeater
{
    /// <summary>
    /// Base of weapon generator
    /// </summary>
    public abstract class BaseWeaponGenerator
    {
        private readonly Random random = new Random();
        private readonly PathManager pathManager;

        /// <summary>
        /// Bonuses for sword blades
        /// </summary>
        protected static readonly Dictionary<string, CreatorBonus> BladeBonuses = new Dictionary<string, CreatorBonus>
        {
            { "human", new CreatorBonus{ Damage = 1.1 } },
            { "elf",   new CreatorBonus{ FightSpeed = 1.15 } },
            { "dwarf", new CreatorBonus{ CriticalHitChance = 5 } },
            { "orc",   new CreatorBonus{ Value = 0.85 } },
            { "daemon",new CreatorBonus{ Damage = 1.40, FightSpeed = 0.90, Value = 1.10 } }
        };

        /// <summary>
        /// Bonuses for sword handles
        /// </summary>
        protected static readonly Dictionary<string, CreatorBonus> HandleBonuses = new Dictionary<string, CreatorBonus>
        {
            { "human", new CreatorBonus{ CriticalHitChance = 5} },
            { "elf",   new CreatorBonus{ Damage = 1.25 } },
            { "dwarf", new CreatorBonus{ Damage = 1.50, Value = 1.30 } },
            { "orc",   new CreatorBonus{ FightSpeed = 1.20} },
            { "daemon",new CreatorBonus{ CriticalHitChance = 10, Damage = 0.90 } }
        };

        /// <summary>
        /// Initialize weapon generator
        /// </summary>
        /// <param name="pathManager">Manager of game file paths</param>
        protected BaseWeaponGenerator(PathManager pathManager)
        {
            this.pathManager = pathManager;
        }

        /// <summary>
        /// Save weapon picture to *bmp file
        /// </summary>
        /// <param name="weapon">Weapon for saving</param>
        protected void SaveToFile(IWeapon weapon)
        {
            var fileName = string.Format("{0}.bmp", weapon.Stats.Name);
            var filePath = Path.Combine(pathManager.CreatedSwordsDirectory, fileName);
            weapon.Picture.Save(filePath);
        }

        /// <summary>
        /// Returns true, when need create legendary weapon
        /// </summary>
        /// <param name="legendaryWeaponChance">Chance for legendary weapon creating</param>
        /// <returns>True, when weapon is legendary</returns>
        protected bool IsLegendaryWeapon(int legendaryWeaponChance)
        {
            return random.Next(legendaryWeaponChance) == 0;
        }

        /// <summary>
        /// Apply creator's bonus
        /// </summary>
        /// <param name="weapon">Updated weapon</param>
        /// <param name="weaponPart">Part of weapon with bonus</param>
        /// <param name="bonuses"></param>
        protected static void ApplyBonus(IWeapon weapon, string creator, Dictionary<string, CreatorBonus> bonuses)
        {
            if (bonuses.ContainsKey(creator))
            {
                var bonus = bonuses[creator];
                bonus.Apply(weapon);
            }
        }

        /// <summary>
        /// Get random item from collection
        /// </summary>
        /// <typeparam name="T">Type of collection items</typeparam>
        /// <param name="items">Collection of items</param>
        /// <returns>Random item</returns>
        protected T GetRandomItem<T>(IReadOnlyList<T> items)
        {
            var index = random.Next(items.Count());
            return items[index];
        }
    }
}