using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    interface IWeapon
    {
        string GetDescription();
        int GetBonusDamage();
    }

    class BasicSword : IWeapon
    {
        public string GetDescription()
        {
            return "Stupid sword";
        }

        public int GetBonusDamage()
        {
            return 5;
        }
    }
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
        // Thêm thuộc tính Vũ khí cho người chơi
        public IWeapon CurrentWeapon { get; set; }

        // Override lại hàm tính sát thương để cộng thêm từ vũ khí
        public override void Attack(IDamageable target)
        {
            bool isCrit;
            // Tổng sát thương = Sát thương gốc của nhân vật + Sát thương của vũ khí
            int totalBaseDamage = this.Damage + (CurrentWeapon != null ? CurrentWeapon.GetBonusDamage() : 0);
            int finalDamage = GameHelper.CalculateDamage(totalBaseDamage, out isCrit);

            if (CurrentWeapon != null)
            {
                Console.WriteLine($"⚔️ {Name} vung [{CurrentWeapon.GetDescription()}] tấn công!");
            }
            else
            {
                Console.WriteLine($"⚔️ {Name} đấm tay không!");
            }

            target.TakeDamage(finalDamage);
        }

        // Bạn nhớ bổ sung thêm hàm trống cho hàm Attack overload chứa skillName để tránh lỗi abstract nhé
        public override void Attack(IDamageable target, string skillName) { }
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
