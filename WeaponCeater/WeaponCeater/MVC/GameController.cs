namespace WeaponCeater
{
    /// <summary>
    /// Implements application logic
    /// </summary>
    public class GameController
    {
        private readonly GameModel model;
        private readonly GameView view;

        /// <summary>
        /// Initialize MVC pattern
        /// </summary>
        /// <param name="model">Game model</param>
        /// <param name="view">Game view</param>
        public GameController(GameModel model, GameView view)
        {
            this.model = model;
            this.view = view;

            SubscribeToModelEvents(model);
        }

        private void SubscribeToModelEvents(GameModel model)
        {
            model.AllActionsCompleted += Model_AllActionsCompleted;
            model.WeaponFound += Model_WeaponFounded;
            model.NeedExchangeWeapon += Model_NeedExchangeWeapon;
        }

        /// <summary>
        /// Start controller
        /// </summary>
        public void Run()
        {
            model.DoActions();
        }

        private void Model_NeedExchangeWeapon(IWeapon weapon)
        {
            var needExchange = view.AskSwordReplace();
            if (needExchange)
            {
                var index = view.AskInventoryBagIndex(1, Inventory.MaxWeaponCount);
                model.ExchangeWeapon(weapon, index);
            }
            view.ShowInventory(model.Inventory);
        }

        private void Model_WeaponFounded(IWeapon weapon)
        {
            view.ShowWeapon(weapon);

            model.TryAddWeaponToInventory(weapon);
        }

        private void Model_AllActionsCompleted()
        {
            ShowTotalWeaponCost();
            CheckPicturesDeleting();
            WaitInput();
        }

        private void WaitInput()
        {
            view.WaitInput();
        }

        private void ShowTotalWeaponCost()
        {
            var cost = model.GetTotalWeaponCost();
            view.ShowTotalCost(cost);
        }

        private void CheckPicturesDeleting()
        {
            var needRemovePictures = view.AskPictureRemoving();
            if (needRemovePictures)
            {
                RemovePictures();
            }
            else
            {
                ShowPicutesSavedMessage();
            }
        }

        private void ShowPicutesSavedMessage()
        {
            var directory = model.GetCreatedWeaponDirectory();
            view.ShowCheckDirectoryMessage(directory);
        }

        private void RemovePictures()
        {
            model.RemoveCreatedPictures();
            view.ShowPicturesDeletedMessage();
        }
    }
}