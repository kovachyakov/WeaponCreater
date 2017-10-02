using System;
using System.IO;

namespace WeaponCeater
{
    /// <summary>
    /// Implements game model
    /// </summary>
    public class GameModel
    {
        private const int ChestLegendaryWeaponChance = 5;
        private const int EnemyLegendaryWeaponChance = 10;

        private readonly IWeaponGenerator weaponGenerator;
        private readonly string createdSwordsDirectory;

        /// <summary>
        /// Stored weapons
        /// </summary>
        public Inventory Inventory { get; private set; }

        /// <summary>
        /// Called, when all game actions completed
        /// </summary>
        public event Action AllActionsCompleted;
        /// <summary>
        /// Called, when weapon was found
        /// </summary>
        public event Action<IWeapon> WeaponFound;
        /// <summary>
        /// Called, when inventory is full
        /// </summary>
        public event Action<IWeapon> NeedExchangeWeapon;

        /// <summary>
        /// Initializes game model
        /// </summary>
        /// <param name="weaponGenerator">Generator of weapon</param>
        /// <param name="createdSwordsDirectory">Directory for created swords saving</param>
        public GameModel(IWeaponGenerator weaponGenerator, string createdSwordsDirectory)
        {
            this.weaponGenerator = weaponGenerator;
            this.createdSwordsDirectory = createdSwordsDirectory;

            Inventory = new Inventory();
        }

        /// <summary>
        /// Get total cost of all stored weapons
        /// </summary>
        /// <returns>Sum of weapon costs</returns>
        public int GetTotalWeaponCost()
        {
            return Inventory.GetTotalCost();
        }

        /// <summary>
        /// Replace weapon on index by another weapon
        /// </summary>
        /// <param name="weapon">New weapon</param>
        /// <param name="index">Index for exchange</param>
        public void ExchangeWeapon(IWeapon weapon, int index)
        {
            Inventory.RemoveAt(index);
            Inventory.Add(weapon);
        }

        /// <summary>
        /// Try add weapon to inventory, if it is not full
        /// </summary>
        /// <param name="weapon">New weapon</param>
        public void TryAddWeaponToInventory(IWeapon weapon)
        {
            if (Inventory.IsFull())
            {
                NeedExchangeWeapon.Raise(weapon);
            }
            else
            {
                Inventory.Add(weapon);
            }
        }

        /// <summary>
        /// Returns directory for created weapon pictures store
        /// </summary>
        /// <returns>Directory path</returns>
        public string GetCreatedWeaponDirectory()
        {
            return createdSwordsDirectory;
        }

        /// <summary>
        /// Clear directory of saved pictures
        /// </summary>
        public void RemoveCreatedPictures()
        {
            var files = new DirectoryInfo(createdSwordsDirectory).GetFiles();
            foreach (var file in files)
            {
                file.Delete();
            }
        }

        /// <summary>
        /// Run game actions
        /// </summary>
        public void DoActions()
        {
            FindWeapons();
            AllActionsCompleted.Raise();
        }

        private void FindWeapons()
        {
            FindChest();
            KillEnemy();
            FindChest();
            KillEnemy();
            FindChest();
            KillEnemy();
            FindChest();
            KillEnemy();
        }

        private void FindChest()
        {
            FindWeapon(ChestLegendaryWeaponChance);
        }

        private void KillEnemy()
        {
            FindWeapon(EnemyLegendaryWeaponChance);
        }

        private void FindWeapon(int legendaryWeaponChance)
        {
            var weapon = weaponGenerator.Generate(legendaryWeaponChance);
            WeaponFound.Raise(weapon);
        }
    }

    /// <summary>
    /// Extension for safe event raise
    /// </summary>
    public static class EventExtensions
    {
        /// <summary>
        /// Safe raise event
        /// </summary>
        /// <param name="eventHandler">Handler of event</param>
        public static void Raise(this Action eventHandler)
        {
            var handler = eventHandler;
            if (handler != null)
            {
                handler();
            }
        }

        /// <summary>
        /// Safe raise event
        /// </summary>
        /// <typeparam name="T">Type of event parameter</typeparam>
        /// <param name="eventHandler">Handler of event</param>
        /// <param name="arg">Parameter of event</param>
        public static void Raise<T>(this Action<T> eventHandler, T arg)
        {
            var handler = eventHandler;
            if (handler != null)
            {
                handler(arg);
            }
        }
    }
}