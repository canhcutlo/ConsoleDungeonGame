using ConsoleDungeonGame;

namespace ConsoleDungeonGame
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("===Welcome to the Dungeon Game===");

        //    //player
        //    Player player = new Player();
        //    Console.Write("Enter your name: ");
        //    player.Name = Console.ReadLine();
        //    player.HP = 100;
        //    player.Damage = 20;

        //    //monsters
        //    Monster Goblin = new Monster { Name = "Stupid Goblin", HP = 30, Damage = 5 };

        //    //a box
        //    DestructibleBox box = new DestructibleBox { HP = 300 };
        //    //Monster[] monsters = new Monster[]
        //    //{
        //    //    new Monster { Name = "Stupid Goblin", HP = 30, Damage = 5 },
        //    //    new Monster { Name = "Superfat Orc", HP = 50, Damage = 10 },
        //    //    new Monster { Name = "acrobatics Dragon", HP = 100, Damage = 20 }
        //    //};

        //    //Console.WriteLine($"A stupid goblin appears! Prepare for battle, {player.Name}!");

        //    ////loop for combat
        //    //while (player.HP > 0 && Goblin.HP > 0)
        //    //{
        //    //    player.Attack(Goblin);
        //    //    if (Goblin.HP == 0) break;

        //    //    Console.ReadLine();
        //    //    Goblin.Attack(player);
        //    //    string status = $"-> [Player status] {player.Name} : {player.HP} | {Goblin.Name} : {Goblin.HP} HP";
        //    //    GameHelper.PrintColor(status, ConsoleColor.Green);
        //    //    Console.WriteLine(new string('-', 40));
        //    //    Console.ReadLine();
        //    //}

        //    //if (player.HP > 0)
        //    //{
        //    //    Console.WriteLine($"Congratulations, {player.Name}! You have defeated the {Goblin.Name}!");
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine($"You have been defeated by the {Goblin.Name}. Better luck next time, {player.Name}.");
        //    //}

        //    player.Attack(box, "Slash");
        //}


        //static void Main(string[] args)
        //{
        //    GameHelper.PrintColor("=== WELCOME TO DUNGEON FACTORY ===", ConsoleColor.Cyan);

        //    Console.Write("Enter your name: ");
        //    Player player = new Player { Name = Console.ReadLine(), HP = 150, Damage = 25 };

        //    for (int level = 1; level <= 3; level++)
        //    {
        //        Console.WriteLine($"\n---------------- FLOOR {level} ----------------");

        //        // USE FACTORY TO SPAWN A MONSTER BASED ON THE CURRENT DUNGEON LEVEL
        //        Monster enemy = MonsterFactory.SpawnRandomMonster(level);

        //        GameHelper.PrintColor($"⚠️ [WARNING] A {enemy.Name} blocks your path on this floor! (HP: {enemy.HP})", ConsoleColor.DarkYellow);
        //        Console.ReadLine();

        //        while (player.HP > 0 && enemy.HP > 0)
        //        {
        //            player.Attack(enemy);
        //            if (enemy.HP == 0) break;

        //            Console.WriteLine();
        //            enemy.Attack(player);
        //            Console.ReadLine();
        //        }

        //        if (player.HP <= 0)
        //        {
        //            GameHelper.PrintColor(" You have perished in the dungeon!", ConsoleColor.DarkRed);
        //            break;
        //        }

        //        GameHelper.PrintColor($" You have defeated {enemy.Name} and proceed to the next floor!", ConsoleColor.Green);
        //    }

        //    if (player.HP > 0)
        //    {
        //        GameHelper.PrintColor(" CONGRATULATIONS! You have conquered the entire dungeon!", ConsoleColor.Magenta);
        //    }
        //}

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Enter your name: ");
            Player player = new Player { Name = Console.ReadLine(), HP = 100, Damage = 10 };
            Monster goblin = new Monster { Name = "Goblin", HP = 50, Damage = 5 };
            
            //basic weapon
            IWeapon mySword = new BasicSword();
            player.CurrentWeapon = mySword;
            player.Attack(goblin);
            Console.WriteLine();

            // Enchant FireAspect
            GameHelper.PrintColor("you got fireaspect, your weapon is enchanted...", ConsoleColor.Yellow);
            mySword = new FireElement(mySword); 
            player.CurrentWeapon = mySword;
            player.Attack(goblin); 
            Console.WriteLine();

            // enchant FrozenAspect
            GameHelper.PrintColor("you got Frozenaspect, your weapon is contnue enchanted...", ConsoleColor.Cyan);
            mySword = new IceElement(mySword); 
            player.CurrentWeapon = mySword;
            player.Attack(goblin);
        }
    }
}