using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Stupid Goblin";
            HP = 30;
            Damage = 5;
        }
    }

    class Orc : Monster
    {
        public Orc()
        {
            Name = "Superfat Orc";
            HP = 50;
            Damage = 10;
        }
    }

    class Dragon : Monster
    {
        public Dragon()
        {
            Name = "acrobatics Dragon";
            HP = 100;
            Damage = 20;
        }
    }

    class MonsterFactory
    {
        private static Random random = new Random();

        // Factory Method: Trả về kiểu lớp cha (Monster) chứ không trả về class cụ thể
        public static Monster CreateMonster(string type)
        {
            switch (type.ToLower())
            {
                case "easy":
                    return new Goblin();
                case "medium":
                    return new Orc();
                case "boss":
                    return new Dragon();
                default:
                    throw new ArgumentException("Loại quái vật không hợp lệ!");
            }
        }

        //Factory method
        public static Monster SpawnRandomMonster(int dungeonLevel)
        {
            int roll = random.Next(1, 101);

            if (dungeonLevel <= 3)
            {
                return roll <= 70 ? new Goblin() : new Orc();
            }
            else
            {
                if (roll <= 20) return new Goblin();
                if (roll <= 70) return new Orc();
                return new Dragon();
            }
        }
    }
}
