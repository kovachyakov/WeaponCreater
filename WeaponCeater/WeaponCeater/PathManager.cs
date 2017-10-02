using System.IO;

namespace WeaponCeater
{
    /// <summary>
    /// Manager of game file paths
    /// </summary>
    public class PathManager
    {
        /// <summary>
        /// Static consturctor
        /// </summary>
        public PathManager()
        {
            var basePath = new DirectoryInfo(Directory.GetCurrentDirectory())
                                    .Parent.Parent.Parent
                                    .FullName;

            SwordBladesDirectory = Path.Combine(basePath, "swordblade.txt");
            SwordHandlesDirectory = Path.Combine(basePath, "swordhandle.txt");
            LegendarySwordsDirectory = Path.Combine(basePath, "lgsw.txt");
            PicturesPath = Path.Combine(basePath, "images");
            CreatedSwordsDirectory = Path.Combine(basePath, "CreatedSword");
        }

        public string CreatedSwordsDirectory { get; set; }
        public string PicturesPath { get; set; }
        public string LegendarySwordsDirectory { get; set; }
        public string SwordBladesDirectory { get; set; }
        public string SwordHandlesDirectory { get; set; }
    }
}