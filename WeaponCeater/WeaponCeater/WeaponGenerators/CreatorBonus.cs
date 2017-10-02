using System;

namespace WeaponCeater
{
    /// <summary>
    /// Weapon creator's bonus
    /// </summary>
    public class CreatorBonus
    {
        public double Damage { get; set; }
        public double FightSpeed { get; set; }
        public int CriticalHitChance { get; set; }
        public double Value { get; set; }

        /// <summary>
        /// Initialize default values for bonus
        /// </summary>
        public CreatorBonus()
        {
            Damage = 1.0;
            FightSpeed = 1.0;
            CriticalHitChance = 0;
            Value = 1.0;
        }

        /// <summary>
        /// Apply bonus to weapon
        /// </summary>
        /// <param name="weapon">Updated weapon</param>
        public void Apply(IWeapon weapon)
        {
            weapon.Stats.Damage = Convert.ToInt32(weapon.Stats.Damage * Damage);
            weapon.Stats.Fightspeed = Convert.ToInt32(weapon.Stats.Fightspeed * FightSpeed);
            weapon.Stats.Value = Convert.ToInt32(weapon.Stats.Value * Value);
            weapon.Stats.CriticalHitChance = weapon.Stats.CriticalHitChance + CriticalHitChance;
        }
    }
}