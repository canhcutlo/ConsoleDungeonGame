using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    class Player
    {
        //attribute
        public string Name;
        public int HP;
        public int Damage;

        //action
        public void Attack (Monster target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}, {Damage} damaged!");
            target.HP -= Damage;
        }

    }

    class Monster
    {
        public string Name;
        public int HP;
        public int Damage;

        public void Attack(Player target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}, {Damage} damaged!");
            target.HP -= Damage;
        }
    }
}
