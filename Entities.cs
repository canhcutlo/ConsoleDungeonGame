using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    class Player
    {
        //attribute
        public string Name { get; set; }
        private int hp;
        public int HP
        {
            get { return hp; }
            set { if (value < 0) hp = 0; else hp = value; } // Ensure HP does not go below 0
        }
        public int Damage { get; set; }

        //action
        public void Attack (Monster target)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);
            if(isCrit)
            {
                Console.WriteLine($"{Name} attacks {target.Name}, {finalDamage} damage! Critical hit!");
            }
            else
            {
                Console.WriteLine($"{Name} attacks {target.Name}, {finalDamage} damage!");
            }
            int oldHP = target.HP;
            target.HP -= finalDamage;

            GameHelper.PrintColor($"{target.Name} HP: {oldHP} -> {target.HP}", ConsoleColor.Red);
            
        }

    }

    class Monster
    {
        public string Name { get; set; }
        private int hp;
        public int HP
        {
            get { return hp; }
            set { if (value < 0) hp = 0; else hp = value; } // Ensure HP does not go below 0
        }
        public int Damage { get; set; }

        public void Attack(Player target)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);
            if(isCrit)
            {
                Console.WriteLine($"{Name} attacks {target.Name}, {finalDamage} damage! Critical hit!");
            }
            else
            {
                Console.WriteLine($"{Name} attacks {target.Name}, {finalDamage} damage!");
            }

            int oldHp = target.HP;
            target.HP -= finalDamage;
            GameHelper.PrintColor($"{target.Name} HP: {oldHp} -> {target.HP}", ConsoleColor.Red);
            
        }
    }
}
