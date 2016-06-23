using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlaying
{
    class Program
    {
        //protected static int origRow;
        //protected static int origCol;

        //protected static void WriteAt(string s, int x, int y)
        //{
        //    try
        //    {
        //        Console.SetCursorPosition(origCol + x, origRow + y);
        //        Console.Write(s);
        //    }
        //    catch (ArgumentOutOfRangeException e)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(e.Message);
        //    }
        //}

        static Hero MyHero = new Hero
        {
            Name = "Brienne",
            Offense = 4,
            Defense = 2,
            MaxHitPoints = 25,
            HitPoints = 25,
        };

        static Dragon MyEnemy = new Dragon
        {
            Name = "Drogon",
            Offense = 16,
            Defense = 12,
            MaxHitPoints = 60,
            HitPoints = 60
        };


        /// <summary>
        /// Runs a battle between a Hero and a Dragon. Ends when one of them has 0 HitPoints.
        /// </summary>
        /// <param name="hero">The Hero in the battle.</param>
        /// <param name="enemy">The Dragon in the battle.</param>
        static void Battle(Hero hero, Dragon enemy)
        {
            //Console.Clear();

            //origRow = Console.CursorTop;
            //origCol = Console.CursorLeft;


            // TODO++: modify Battle to take a List<Dragon> of enemies, and have each of them attack every time through the loop.
            // You may want to have the Hero automatically attack the first enemy in the list that is still alive.
            Die myDie = new Die(20);
            Console.WriteLine(MyHero+"\n");

            Console.WriteLine("VERSUS \n");

            Console.WriteLine(MyEnemy);

            int Phase = 1;
            List<Dragon> Enemies = new List<Dragon>
            {
                new Dragon() { Name = "Spike", Offense = 8, Defense = 6,
                               MaxHitPoints = 30, HitPoints = 30},
                new Dragon() { Name = "Spyro", Offense = 4, Defense = 3,
                               MaxHitPoints = 15, HitPoints = 15}
            };

            while (MyHero.IsAlive())
            {
                //Console.WriteLine("Select an enemmy to attack");
                //Enemies.ForEach(Console.WriteLine);
                //Console.ReadKey();


                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Battle Phase {0}\n", Phase);
                Console.ResetColor();

                int currHP = MyEnemy.HitPoints;
                int attackRoll = myDie.Roll();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rolled {0} for attack phase\n", attackRoll);
                MyHero.Attack(MyEnemy, attackRoll);
                Console.WriteLine("{0} has taken {1} damage!\n", MyEnemy.Name, currHP - MyEnemy.HitPoints);
                Console.WriteLine(MyEnemy);
                //WriteAt(MyEnemy.ToString(), 0, 16);
                //WriteAt(MyEnemy.Name.ToString(), 0, 16);
                //WriteAt(MyEnemy.Offense.ToString(), 0, 17);
                //Console.ReadKey();
                Console.ResetColor();

                int HeroHP = MyHero.HitPoints;
                if (!MyEnemy.IsAlive())
                {
                    Console.WriteLine("{0} slayed {1}!", MyHero.Name, MyEnemy.Name);
                    break;
                }
                int defenseRoll = myDie.Roll();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Rolled {0} for defense phase\n", defenseRoll);
                MyHero.Defend(MyEnemy, defenseRoll);
                Console.WriteLine("{0} has taken {1} damage!\n", MyHero.Name, HeroHP - MyHero.HitPoints);
                Console.WriteLine(MyHero);
                //WriteAt(MyHero.ToString(), 30, 16);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("----------------------------------\n\n\n");
                Console.ResetColor();

                Phase++;
            }

            if (!MyHero.IsAlive())
            {
                Console.WriteLine("{0} was defeated by {1}. :(", MyHero.Name, MyEnemy.Name);
            }

        }

        static void Main(string[] args)
        {

            Console.WriteLine("{0} must slay {1} to continue on the journey.\n", MyHero.Name, MyEnemy.Name);

            //Console.WriteLine(MyHero);

            Battle(MyHero, MyEnemy);

            Console.ReadLine();
        }
    }
}
