using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    class GameEntity
    {
        public string Name { get; set; }
        private int hp;
        public int HP
        {
            get { return hp; }
            set { if (value < 0) hp = 0; else hp = value; } // Ensure HP doesn't go below 0
        }
        public int Damage { get; set; }

        public virtual void Attack(GameEntity target)
        {
            bool isCrit;
            int  finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);

            if (isCrit)
            {
                GameHelper.PrintColor($"Critical hit! {this.Name} damage to {target.Name}.", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine($"{this.Name} damage to {target.Name}.");
            }

            ApplyDamage(target, finalDamage);
        }

        public virtual void Attack(GameEntity target, string skillName)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage + 15, out isCrit);

            GameHelper.PrintColor($"{this.Name} uses {skillName} on {target.Name}.", ConsoleColor.Cyan);
            if (isCrit) 
            {
                GameHelper.PrintColor($"Critical hit! {this.Name} damage to {target.Name}.", ConsoleColor.Red);
            }

            ApplyDamage(target, finalDamage);

        }

        private void ApplyDamage(GameEntity target, int damageAmount)
        {
            int oldHP = target.HP;
            target.HP -= damageAmount;
            GameHelper.PrintColor($"{target.Name} HP: {oldHP} -> {target.HP}", ConsoleColor.Red);
        }
    
    }
    class Player : GameEntity
    {
        //overide
        public override void Attack(GameEntity target)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);

            if (isCrit)
            {
                Console.WriteLine($"{Name} Crit hit {target.Name}!  {finalDamage} damaged!");
            }
            else
            {
                Console.WriteLine($"{Name} slash {target.Name}, {finalDamage} damaged.");
            }

            int oldHP = target.HP;
            target.HP -= finalDamage;
            GameHelper.PrintColor($"{target.Name} HP: {oldHP} -> {target.HP}", ConsoleColor.Red);
        }
    }

    class Monster : GameEntity
    {
        // Ghi đè lại để có lời thoại tấn công hung tợn của Quái vật
        public override void Attack(GameEntity target)
        {
            bool isCrit;
            int finalDamage = GameHelper.CalculateDamage(this.Damage, out isCrit);

            if (isCrit)
            {
                Console.WriteLine($"{Name} Stupid attack {target.Name}! {finalDamage} damaged!");
            }
            else
            {
                Console.WriteLine($"{Name} dump attak {target.Name}, {finalDamage} damaged.");
            }

            int oldHP = target.HP;
            target.HP -= finalDamage;
            GameHelper.PrintColor($"{target.Name} HP: {oldHP} -> {target.HP}", ConsoleColor.Red);
        }
    }
}
