using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    interface IDamageable
    {
        int HP { get; set; }
        void TakeDamage(int amount);
    }
    abstract class GameEntity : IDamageable
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        private int hp;
        public int HP
        {
            get { return hp; }
            set { if (value < 0) hp = 0; else hp = value; }
        }

        public void TakeDamage(int amount)
        {
            int oldHP = this.HP;
            this.HP -= amount;
            GameHelper.PrintColor($"{Name} HP: {oldHP} -> {this.HP}", ConsoleColor.Red);
        }

        public abstract void Attack(IDamageable target);
        public abstract void Attack(IDamageable target, string skillName); //over load
    }


    class Player : GameEntity
    {
        public override void Attack(IDamageable target)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);

            if (isCrit) Console.WriteLine($" {Name} Crit hit!");
            else Console.WriteLine($" {Name} hit.");

            target.TakeDamage(finalDamage); // Gọi hàm chịu sát thương của mục tiêu
        }

        public override void Attack(IDamageable target, string skillName)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage + 15, out isCrit);

            GameHelper.PrintColor($"{Name} used skill [{skillName}]!", ConsoleColor.Yellow);
            target.TakeDamage(finalDamage);
        }
    }

    class Monster : GameEntity
    {
        public override void Attack(IDamageable target)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);

            Console.WriteLine($"{Name} stupid attack.");
            target.TakeDamage(finalDamage);
        }

        public override void Attack(IDamageable target, string skillName)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage + 5, out isCrit);

            GameHelper.PrintColor($" {Name} dumb attack [{skillName}]!", ConsoleColor.DarkRed);
            target.TakeDamage(finalDamage);
        }
    }

    class DestructibleBox : IDamageable
    {
        public string Name { get; set; } = "a weird box";

        private int hp;
        public int HP
        {
            get { return hp; }
            set { if (value < 0) hp = 0; else hp = value; }
        }

        public void TakeDamage(int amount)
        {
            int oldHP = this.HP;
            this.HP -= amount;
            Console.WriteLine($"the box {Name} is brokening!");
            GameHelper.PrintColor($"{Name} durabity: {oldHP} -> {this.HP}", ConsoleColor.DarkYellow);

            if (this.HP == 0)
            {
                GameHelper.PrintColor($"{Name} is broken! you bastard!", ConsoleColor.Cyan);
            }
        }
    }
}
