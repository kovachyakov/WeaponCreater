namespace WeaponCeater
{
    class Program
    {
        static void Main()
        {
            var game = CreateGame();
            game.Run();
        }

        private static GameController CreateGame()
        {
            var model = GetModel();
            var view = GetView();

            return new GameController(model, view);
        }

        private static GameModel GetModel()
        {
            var pathManager = new PathManager();
            var swordLoader = new SwordLoader(pathManager);
            var weaponGenerator = new SwordGenerator(swordLoader, pathManager);

            var game = new GameModel(weaponGenerator, pathManager.CreatedSwordsDirectory);

            return game;
        }

        private static GameView GetView()
        {
            return new GameView();
        }
    }
}
