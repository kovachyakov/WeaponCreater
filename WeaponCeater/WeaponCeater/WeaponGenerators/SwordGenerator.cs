using System.Collections.Generic;
using System.Drawing;

namespace WeaponCeater
{
    /// <summary>
    /// Generator of weapons
    /// </summary>
    public class SwordGenerator : BaseWeaponGenerator, IWeaponGenerator
    {
        private readonly List<LegendarySword> legendarySwords;
        private readonly List<SwordBlade> swordBlades;
        private readonly List<SwordHandle> swordHandles;

        /// <summary>
        /// Initialize sword generator
        /// </summary>
        /// <param name="loader">Loader of sword data</param>
        /// <param name="pathManager">Storage of game files paths</param>
        public SwordGenerator(SwordLoader loader, PathManager pathManager)
            : base(pathManager)
        {
            legendarySwords = loader.LoadLegendarySwords();
            swordBlades = loader.LoadSwordBlades();
            swordHandles = loader.LoadSwordHandles();
        }

        /// <summary>
        /// Generate sword
        /// </summary>
        /// <param name="legendaryWeaponChance">Chance to create legendary weapon</param>
        /// <returns>Generated sword</returns>
        public IWeapon Generate(int legendaryWeaponChance)
        {
            ISword sword;
            if (IsLegendaryWeapon(legendaryWeaponChance))
                sword = GenereateLegendarySword();
            else
                sword = GenerateSword();

            SaveToFile(sword);

            return sword;
        }

        private LegendarySword GenereateLegendarySword()
        {
            return GetRandomItem(legendarySwords);
        }

        private Sword GenerateSword()
        {
            var blade = GetRandomItem(swordBlades);
            var handle = GetRandomItem(swordHandles);

            var sword = GenerateSword(blade, handle);

            return sword;
        }

        private static Sword GenerateSword(SwordBlade blade, SwordHandle handle)
        {
            var swordStats = blade.Stats.Combine(handle.Stats);
            var picture = CombinePictures(blade.Picture, handle.Picture);

            var sword = new Sword
            {
                Stats = swordStats,
                Picture = picture,
            };
            ApplyBonus(sword, blade.Stats.Creator, BladeBonuses);
            ApplyBonus(sword, handle.Stats.Creator, HandleBonuses);

            return sword;
        }

        private static Bitmap CombinePictures(Bitmap bladeBitamp, Bitmap handleBitmap)
        {
            var result = new Bitmap(bladeBitamp);
            for (var x = 0; x < handleBitmap.Width; ++x)
            {
                for (var y = 400; y < handleBitmap.Height; ++y)
                {
                    var color = handleBitmap.GetPixel(x, y);
                    result.SetPixel(x, y, color);
                }
            }
            return result;
        }
    }
}