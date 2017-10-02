using System;

namespace WeaponCeater
{
    /// <summary>
    /// User intergace for game
    /// </summary>
    public class GameView
    {
        /// <summary>
        /// Show list of weapon from inventory
        /// </summary>
        /// <param name="inventory">Storage of weapons</param>
        public void ShowInventory(Inventory inventory)
        {
            Console.WriteLine();
            Console.WriteLine("Your swords:");
            foreach (var weapon in inventory)
            {
                Console.WriteLine(weapon.Stats.Name);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Ask request for weapon exchange
        /// </summary>
        /// <returns></returns>
        public bool AskSwordReplace()
        {
            var question = "Your bag is full! Do you want to exchange mySword?(Y / N)";
            return AskYesNoQuestion(question);
        }

        private bool AskYesNoQuestion(string question)
        {
            Console.WriteLine(question);
            string answer;
            do
            {
                var line = Console.ReadLine();
                if (line == null) return false;

                answer = line.ToLower();

            } while (answer != "y" && answer != "n");

            return answer == "y";
        }

        /// <summary>
        /// Wait user input
        /// </summary>
        public void WaitInput()
        {
            Console.ReadLine();
        }

        /// <summary>
        /// Ask index of weapon from inventory
        /// </summary>
        /// <param name="minValue">Min available index</param>
        /// <param name="maxValue">Max available index</param>
        /// <returns></returns>
        public int AskInventoryBagIndex(int minValue, int maxValue)
        {
            var message = string.Format("Enter number in ({0}..{1})", minValue, maxValue);
            Console.Write("Enter a number of the mySword that you want to discard. ");
            int index;
            bool correctNumber;
            do
            {
                Console.WriteLine(message);
                var line = Console.ReadLine();
                if (line == null) return -1;
                correctNumber = int.TryParse(line, out index);
            } while (!correctNumber);

            return index - 1;
        }

        /// <summary>
        /// Print cost of all weapons
        /// </summary>
        /// <param name="totalCost">Cost of all weapons</param>
        public void ShowTotalCost(int totalCost)
        {
            var message = string.Format("If you sell all swords you will earn {0} coins.", totalCost);
            Console.WriteLine();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Ask request for created pictures removing
        /// </summary>
        /// <returns>True, when user select remove pictures</returns>
        public bool AskPictureRemoving()
        {
            var question = "Do you want delete new pictures?(Y/N)";
            return AskYesNoQuestion(question);
        }

        /// <summary>
        /// Print message about saved pictures
        /// </summary>
        /// <param name="directory">Path to saved pictures</param>
        public void ShowCheckDirectoryMessage(string directory)
        {
            var message = string.Format("Check the directory: {0}", directory);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Print message about deleted pictures
        /// </summary>
        public void ShowPicturesDeletedMessage()
        {
            var message = string.Format("All pictures was deleted.");
            Console.WriteLine(message);
        }

        /// <summary>
        /// Print information about weapon
        /// </summary>
        /// <param name="weapon">Weapon</param>
        public void ShowWeapon(IWeapon weapon)
        {
            Console.WriteLine(weapon.ToString());
        }
    }
}