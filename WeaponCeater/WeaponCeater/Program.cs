using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace WeaponCeater
{
    class Program
    {
        static void Main(string[] args)
        {
            // all comments after the blocks of code

            string alfa = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 9 - 13);
            string SBway = alfa + "swordblade.txt";
            string SHway = alfa + "swordhandle.txt";
            string LGway = alfa + "lgsw.txt";
            string Picway = alfa + @"images\";
            // .txt files way

            List<SwordBlade> Sblade = new List<SwordBlade>();
            List<SwordHandle> Shandle = new List<SwordHandle>();
            List<LegendarySword> legendarySword = new List<LegendarySword>();
            List<Bag> myBag = new List<Bag>();
            Sword mySword = new Sword();
            SwordBlade.ReadData(SBway, Sblade, Picway);
            SwordHandle.ReadData(SHway, Shandle, Picway);
            LegendarySword.ReadData(LGway, legendarySword, Picway);
            Random e = new Random();
            int pocket = 0;
            // lists and variables initialization

            HowIGetWeapon.FindChest(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.KillEnemy(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.FindChest(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.KillEnemy(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.FindChest(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.KillEnemy(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.FindChest(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            HowIGetWeapon.KillEnemy(mySword, legendarySword, Sblade, Shandle, myBag, alfa);
            // get 8 swords 

            Console.WriteLine();
            Console.WriteLine("Your swords:");
            for (int i = 0; i < myBag.Count; i++)
            {
                Console.WriteLine(myBag.ElementAt(i).Name);
            }
            // output of the final bag

            int f = myBag.Count;
            for (int i = 0; i < f; f--)
            {
                pocket += Bag.SellSword(myBag, i);
            }
            Console.WriteLine();
            Console.WriteLine("If you sell all swords you will earn {0} coins.", pocket);
            // calculate the total cost of the swords (.SellSword method)

            Console.WriteLine("Do you want to delet new pictures?(Y/N)");
            if (Console.ReadLine() == "Y")
            {
                DirectoryInfo dirInfo = new DirectoryInfo(alfa+@"CreatedSword");
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                Console.WriteLine("Check the directory " +alfa+ @"CreatedSword");
            }
            // clear CreatedSword directory

            Console.Read();
        }
    }

    class Weapon
    {
        public string Name { get; set; }
        public int Fightspeed { get; set; }
        public int Damage { get; set; }
        public int CriticalHitChance { get; set; }
        public int Value { get; set; }
        public string Imageway { get; set; }
        public string Creator { get; set; }
        public int Level { get; set; }
    }
    // basic class, creates all the characteristics of a sword

    class SwordBlade : Weapon
    {
        public Bitmap bladepic { get; set; }
        public static void ReadData(string way, List<SwordBlade> Sblade, string Picway)
        {

            string qwerty = "";
            int i = 0;
            int j = 0;
            int counter = 0;
            string[] wordlist = { "", "", "", "", "", "", "", "" };
            string line = "";
            StreamReader file = new StreamReader(way);
            while ((qwerty = file.ReadLine()) != null)
            {
                char[] arr = qwerty.ToCharArray();
                i = 0;
                j = 0;
                while (arr[i] != '.')
                {
                    if (arr[i] != ' ')
                    {
                        line += arr[i];
                    }
                    else
                    {
                        wordlist[j] = line;
                        line = "";
                        j++;
                    }
                    i++;
                }

                var a = new SwordBlade();
                a.Name = wordlist[0];
                a.Fightspeed = Convert.ToInt32(wordlist[1]);
                a.Damage = Convert.ToInt32(wordlist[2]);
                a.CriticalHitChance = Convert.ToInt32(wordlist[3]);
                a.Value = Convert.ToInt32(wordlist[4]);
                a.Creator = wordlist[5];
                a.Level = Convert.ToInt32(wordlist[6]);
                a.Imageway = wordlist[7];
                a.bladepic = new Bitmap(Picway+a.Imageway+".bmp");

                Sblade.Add(a);

                counter++;
            }

            file.Close();

        }
    }
    class SwordHandle : Weapon
    {
        public Bitmap handlepic { get; set; }
        public static void ReadData(string way, List<SwordHandle> Shandle, string Picway)
        {

            string qwerty = "";
            int i = 0;
            int j = 0;
            int counter = 0;
            string[] wordlist = { "", "", "", "", "", "", "", "" };
            string line = "";
            StreamReader file = new StreamReader(way);
            //var Dict = new List<Word>();
            while ((qwerty = file.ReadLine()) != null)
            {
                char[] arr = qwerty.ToCharArray();
                i = 0;
                j = 0;
                while (arr[i] != '.')
                {
                    if (arr[i] != ' ')
                    {
                        line += arr[i];
                    }
                    else
                    {
                        wordlist[j] = line;
                        line = "";
                        j++;
                    }
                    i++;
                }

                var a = new SwordHandle();
                a.Name = wordlist[0];
                a.Fightspeed = Convert.ToInt32(wordlist[1]);
                a.Damage = Convert.ToInt32(wordlist[2]);
                a.CriticalHitChance = Convert.ToInt32(wordlist[3]);
                a.Value = Convert.ToInt32(wordlist[4]);
                a.Creator = wordlist[5];
                a.Level = Convert.ToInt32(wordlist[6]);
                a.Imageway = wordlist[7];
                a.handlepic = new Bitmap(Picway + a.Imageway + ".bmp");

                Shandle.Add(a);

                counter++;
            }

            file.Close();

        }
    }
    // .ReadData method (read .txt files)

    class Sword : Weapon
    {
        public Bitmap Swordpic { get; set; }
        public static void MakeSword(List<SwordBlade> Sblade, List<SwordHandle> Shandle, Sword mySword, string alfa)
        {
            Random e = new Random();

            int x = e.Next(0, Sblade.Count - 1);
            int y = e.Next(0, Shandle.Count - 1);

            mySword.Level = (Sblade.ElementAt(x).Level+ Shandle.ElementAt(y).Level)/2;
            mySword.Fightspeed = (Sblade.ElementAt(x).Fightspeed + Shandle.ElementAt(y).Fightspeed) / 2;
            mySword.Damage = (Sblade.ElementAt(x).Damage + Shandle.ElementAt(y).Damage) / 2;
            mySword.CriticalHitChance = (Sblade.ElementAt(x).CriticalHitChance + Shandle.ElementAt(y).CriticalHitChance) / 2;
            mySword.Value = (Sblade.ElementAt(x).Value + Shandle.ElementAt(y).Value) / 2;
            mySword.Creator = Sblade.ElementAt(x).Creator +@"/"+ Shandle.ElementAt(y).Creator;
            mySword.Name = Sblade.ElementAt(x).Name +" "+ Shandle.ElementAt(y).Name;

            
            for (int z = 0; z < Shandle.ElementAt(y).handlepic.Width; z++)
            {
                for (int t = 400; t < Shandle.ElementAt(y).handlepic.Height; t++)
                {
                    Color pixelColor = Shandle.ElementAt(y).handlepic.GetPixel(z, t);
                    Sblade.ElementAt(x).bladepic.SetPixel(z, t, pixelColor);
                }
            }
            mySword.Swordpic = Sblade.ElementAt(x).bladepic;
            
            Sblade.ElementAt(x).bladepic.Save(alfa + @"CreatedSword\"+ mySword.Name +".bmp");



            if (Sblade.ElementAt(x).Creator == "human")
            {
                mySword.Damage=Convert.ToInt32(mySword.Damage*1.1);
            }
            else if (Sblade.ElementAt(x).Creator == "elf") 
            {
                mySword.Fightspeed = Convert.ToInt32(mySword.Fightspeed * 1.15);
            }
            else if (Sblade.ElementAt(x).Creator == "dwarf") 
            {
                mySword.CriticalHitChance = mySword.CriticalHitChance + 5;
            }
            else if (Sblade.ElementAt(x).Creator == "orc")  
            {
                mySword.Value = Convert.ToInt32(mySword.Value * 0.85);
            }
            else if (Sblade.ElementAt(y).Creator == "daemon")
            {
                mySword.Damage = Convert.ToInt32(mySword.Damage * 1.40);
                mySword.Value = Convert.ToInt32(mySword.Value * 1.10);
                mySword.Fightspeed = Convert.ToInt32(mySword.Fightspeed * 0.90);
            }


            if (Shandle.ElementAt(y).Creator == "daemon")
            {
                mySword.CriticalHitChance = mySword.CriticalHitChance +10;
                mySword.Damage = Convert.ToInt32(mySword.Damage * 0.90);
            }
            else if (Shandle.ElementAt(y).Creator == "orc")
            {
                mySword.Fightspeed = Convert.ToInt32(mySword.Fightspeed * 1.20);
            }
            else if (Shandle.ElementAt(y).Creator == "dwarf")
            {
                mySword.Value = Convert.ToInt32(mySword.Value * 1.30);
                mySword.Damage = Convert.ToInt32(mySword.Damage * 1.50);
            }
            else if (Shandle.ElementAt(y).Creator == "elf")
            {
                mySword.Damage = Convert.ToInt32(mySword.Damage * 1.25);
            }
            else if (Shandle.ElementAt(y).Creator == "human")
            {
                mySword.CriticalHitChance = mySword.CriticalHitChance + 5;
            }
        }
        public static void AddToBag(Sword mySword, List<Bag> myBag)
        {
            if (myBag.Count < 6) // 6 is bag capacity (if you want to change it, change '6' and in .AddToBag method in LegendarySword class)
            {
                Bag bag = new Bag
                {
                    Creator = mySword.Creator,
                    CriticalHitChance = mySword.CriticalHitChance,
                    Damage = mySword.Damage,
                    Fightspeed = mySword.Fightspeed,
                    Imageway = mySword.Imageway,
                    Name = mySword.Name,
                    Value = mySword.Value,
                    Level = mySword.Level,
                    Swordpic = mySword.Swordpic
                };
                myBag.Add(bag);
            }
            else
            {
                Console.WriteLine("Your bag is full! Do you want to exchange weapon?(Y / N)");
                if (Console.ReadLine() == "Y")
                {
                   
                    Console.WriteLine("Enter a number of the weapon that you want to discard.(1..{0})", myBag.Count);
                    string op = Console.ReadLine();
                    while ((Convert.ToInt32(op) > myBag.Count)||(Convert.ToInt32(op)==0))
                    {
                        Console.WriteLine("Enter number in (1..{0})", myBag.Count);
                        op = Console.ReadLine();
                    }
                    myBag.Remove(myBag.ElementAt(Convert.ToInt16(op) -1));
                    Bag bag = new Bag
                    {
                        Creator = mySword.Creator,
                        CriticalHitChance = mySword.CriticalHitChance,
                        Damage = mySword.Damage,
                        Fightspeed = mySword.Fightspeed,
                        Imageway = mySword.Imageway,
                        Name = mySword.Name,
                        Value = mySword.Value,
                        Level = mySword.Level,
                        Swordpic = mySword.Swordpic
                    };
                    myBag.Add(bag);
                    Console.WriteLine("Your bag now:");
                    Console.WriteLine("-----------------");
                    foreach (var p in myBag)
                    {
                        Console.WriteLine(p.Name);
                    }
                    Console.WriteLine("-----------------");
                }
            }
        }
    }
    // .MakeSword (combines sword blade and handle) + .AddToBag methods

    class LegendarySword : Weapon
    {
        public Bitmap Swordpic { get; set; }
        public static void AddToBag(LegendarySword mySword, List<Bag> myBag)
        {
            if (myBag.Count < 6) // 6 is bag capacity (if you want to change it, change '6' and in .AddToBag method in Sword class)
            {
                Bag bag = new Bag
                {
                    Creator = mySword.Creator,
                    CriticalHitChance = mySword.CriticalHitChance,
                    Damage = mySword.Damage,
                    Fightspeed = mySword.Fightspeed,
                    Imageway = mySword.Imageway,
                    Name = mySword.Name,
                    Value = mySword.Value,
                    Level = mySword.Level,
                    Swordpic = mySword.Swordpic
                };
                myBag.Add(bag);
            }
            else
            {
                Console.WriteLine("Your bag is full! Do you want to exchange weapon?(Y / N)");
                if (Console.ReadLine() == "Y")
                {
                    Console.WriteLine("Enter a number of the weapon that you want to discard.(1..{0})", myBag.Count);
                    string op = Console.ReadLine();
                    while ((Convert.ToInt32(op) > myBag.Count) || (Convert.ToInt32(op) == 0))
                    {
                        Console.WriteLine("Enter number in (1..{0})", myBag.Count);
                        op = Console.ReadLine();
                    }
                    myBag.Remove(myBag.ElementAt(Convert.ToInt16(op) - 1));
                    Bag bag = new Bag
                    {
                        Creator = mySword.Creator,
                        CriticalHitChance = mySword.CriticalHitChance,
                        Damage = mySword.Damage,
                        Fightspeed = mySword.Fightspeed,
                        Imageway = mySword.Imageway,
                        Name = mySword.Name,
                        Value = mySword.Value,
                        Level = mySword.Level,
                        Swordpic = mySword.Swordpic
                    };
                    myBag.Add(bag);
                    Console.WriteLine("Your bag now:");
                    Console.WriteLine("-----------------");
                    foreach (var p in myBag)
                    {
                        Console.WriteLine(p.Name);
                    }
                    Console.WriteLine("-----------------");
                }
            }
        }

        public static void ReadData(string way, List<LegendarySword> legendarySword, string Picway)
        {
            string qwerty = "";
            int i = 0;
            int j = 0;
            int counter = 0;
            string[] wordlist = { "", "", "", "", "", "", "", "" };
            string line = "";
            StreamReader file = new StreamReader(way);
            while ((qwerty = file.ReadLine()) != null)
            {
                char[] arr = qwerty.ToCharArray();
                i = 0;
                j = 0;
                while (arr[i] != '.')
                {
                    if (arr[i] != ' ')
                    {
                        line += arr[i];
                    }
                    else
                    {
                        wordlist[j] = line;
                        line = "";
                        j++;
                    }
                    i++;
                }

                var a = new LegendarySword();
                a.Name = wordlist[0];
                a.Fightspeed = Convert.ToInt32(wordlist[1]);
                a.Damage = Convert.ToInt32(wordlist[2]);
                a.CriticalHitChance = Convert.ToInt32(wordlist[3]);
                a.Value = Convert.ToInt32(wordlist[4]);
                a.Creator = wordlist[5];
                a.Level = Convert.ToInt32(wordlist[6]);
                a.Imageway = wordlist[7];
                a.Swordpic = new Bitmap(Picway + a.Imageway + ".bmp");

                legendarySword.Add(a);

                counter++;
            }

            file.Close();

        }
    }
    // .ReadData + .AddToBag methods

    class Bag :Weapon
    {
        public Bitmap Swordpic { get; set; }
        public static int SellSword(List<Bag> myBag, int number)
        {
            int t= myBag.ElementAt(number).Value;
            myBag.Remove(myBag.ElementAt(number));
            return t; 
        }
    }
    // .SellSword method

    class HowIGetWeapon 
    {
        public Bitmap pic { get; set; }
        public static void FindChest(Sword mySword,List<LegendarySword> legendarySword,List<SwordBlade> Sblade, List<SwordHandle> Shandle,List<Bag> myBag,string alfa)
        {
            Random e = new Random();
            int u = 0;
            if ((u = e.Next(0, 5)) != 0) // (0, 5) - 1/5 (20%)  chance to get legendary sword
            {

                Sword.MakeSword(Sblade, Shandle, mySword,alfa);
                Console.WriteLine("Name: {0}, Creator: {1}, Level: {2}, Damage: {3}, Fightspeed: {4} hit per s, CriticalHitChance: {5}%, Value: {6}"
                   , mySword.Name
                   , mySword.Creator
                   , mySword.Level
                   , mySword.Damage
                   , mySword.Fightspeed
                   , mySword.CriticalHitChance
                   , mySword.Value);
                Sword.AddToBag(mySword, myBag);

            }
            else
            {

                int q = e.Next(0, legendarySword.Count);

                Console.WriteLine("Name: {0}, Creator: {1}, Level: {2}, Damage: {3}, Fightspeed: {4} hit per s, CriticalHitChance: {5}%, Value: {6}"
               , legendarySword.ElementAt(q).Name
               , legendarySword.ElementAt(q).Creator
               , legendarySword.ElementAt(q).Level
               , legendarySword.ElementAt(q).Damage
               , legendarySword.ElementAt(q).Fightspeed
               , legendarySword.ElementAt(q).CriticalHitChance
               , legendarySword.ElementAt(q).Value);
                legendarySword.ElementAt(q).Swordpic.Save(alfa + @"CreatedSword\" + legendarySword.ElementAt(q).Name + ".bmp");
                LegendarySword.AddToBag(legendarySword.ElementAt(q), myBag);
            }
        }
        public static void KillEnemy(Sword mySword, List<LegendarySword> legendarySword, List<SwordBlade> Sblade, List<SwordHandle> Shandle, List<Bag> myBag,string alfa)
        {
            Random e = new Random();
            int u = 0;
            if ((u = e.Next(0, 10)) != 0) // (0, 10) - 1/10 (10%)  chance to get legendary sword
            {

                Sword.MakeSword(Sblade, Shandle, mySword,alfa);
                Console.WriteLine("Name: {0}, Creator: {1}, Level: {2}, Damage: {3}, Fightspeed: {4} hit per s, CriticalHitChance: {5}%, Value: {6}"
                   , mySword.Name
                   , mySword.Creator
                   , mySword.Level
                   , mySword.Damage
                   , mySword.Fightspeed
                   , mySword.CriticalHitChance
                   , mySword.Value);
                Sword.AddToBag(mySword, myBag);

            }
            else
            {

                int q = e.Next(0, legendarySword.Count);

                Console.WriteLine("Name: {0}, Creator: {1}, Level: {2}, Damage: {3}, Fightspeed: {4} hit per s, CriticalHitChance: {5}%, Value: {6}"
               , legendarySword.ElementAt(q).Name
               , legendarySword.ElementAt(q).Creator
               , legendarySword.ElementAt(q).Level
               , legendarySword.ElementAt(q).Damage
               , legendarySword.ElementAt(q).Fightspeed
               , legendarySword.ElementAt(q).CriticalHitChance
               , legendarySword.ElementAt(q).Value);
                legendarySword.ElementAt(q).Swordpic.Save(alfa + @"CreatedSword\" + legendarySword.ElementAt(q).Name + ".bmp");
                LegendarySword.AddToBag(legendarySword.ElementAt(q), myBag);
            }
        }
    }
    // .FindChest + .KillEnemy  methods
}
