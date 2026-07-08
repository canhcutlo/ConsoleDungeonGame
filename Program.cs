using ConsoleDungeonGame;

namespace ConsoleDungeonGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===Welcome to the Dungeon Game===");

            //player
            Player player = new Player();
            Console.Write("Enter your name: ");
            player.Name = Console.ReadLine();
            player.HP = 100;
            player.Damage = 20;

            //monsters
            Monster Goblin = new Monster { Name = "Stupid Goblin", HP = 30, Damage = 5 };
            //Monster[] monsters = new Monster[]
            //{
            //    new Monster { Name = "Stupid Goblin", HP = 30, Damage = 5 },
            //    new Monster { Name = "Superfat Orc", HP = 50, Damage = 10 },
            //    new Monster { Name = "acrobatics Dragon", HP = 100, Damage = 20 }
            //};

            Console.WriteLine($"A stupid goblin appears! Prepare for battle, {player.Name}!");

            //loop for combat
            while (player.HP > 0 && Goblin.HP > 0)
            {
                player.Attack(Goblin);
                if (Goblin.HP == 0) break;

                Console.ReadLine();
                Goblin.Attack(player);
                string status = $"-> [Player status] {player.Name} : {player.HP} | {Goblin.Name} : {Goblin.HP} HP";
                GameHelper.PrintColor(status, ConsoleColor.Green);
                Console.WriteLine(new string('-', 40));
                Console.ReadLine();
            }

            if (player.HP > 0)
            {
                Console.WriteLine($"Congratulations, {player.Name}! You have defeated the {Goblin.Name}!");
            }
            else
            {
                Console.WriteLine($"You have been defeated by the {Goblin.Name}. Better luck next time, {player.Name}.");
            }
        }

        /// if the monster is attacked, it's hp may be minus to -10 but the lowest hp should be 0. Next, Iwill use Access Modifier & Properties to solve this problem.
    }
}