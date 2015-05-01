using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();

            Console.ReadKey();
        }
    }

    public abstract class Actor
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public bool IsAlive
        {
            get
            {
                return this.HP > 0;
            }
        }

        public Actor(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        public virtual void Attack(Actor actor) { }
    }

    public class Enemy : Actor
    {
        public Enemy(string name, int hp)
            : base(name, hp) { }

        public override void Attack(Actor actor)
        {
            Random rng = new Random();
            int probabilityOfEnemyHit = rng.Next(1, 11);

            if (probabilityOfEnemyHit < 9)
            {
                actor.HP -= rng.Next(5, 16);
                Console.WriteLine("Hans hit you with all his might");
                Thread.Sleep(750);
            }
        }
    }

    public class Player : Actor
    {
        public enum AttackType
        {
            AttackOne = 1,
            AttackTwo,
            Heal
        }

        public Player(string name, int hp)
            : base(name, hp) { }

        public override void Attack(Actor actor)
        {
            Random rng = new Random();
            AttackType attack = ChooseAttack();
            int probabilityOfAttack = 0;
            switch (attack)
            {
                case AttackType.AttackOne:
                    probabilityOfAttack = rng.Next(1, 11);
                    if (probabilityOfAttack < 8)
                    {
                        actor.HP -= rng.Next(20, 36);
                        Console.WriteLine("You hit Hans square in the noggin");
                        Thread.Sleep(750);
                    }
                    else
                    {
                        Console.WriteLine("Your kicking skills were not up to par");
                        Thread.Sleep(750);
                    }
                    break;
                case AttackType.AttackTwo:
                    actor.HP -= rng.Next(10, 16);
                    Console.WriteLine("Body Blow!");
                    Thread.Sleep(750);
                    break;
                case AttackType.Heal:
                    this.HP += rng.Next(10, 21);
                    Console.WriteLine("You became more BadAss");
                    Thread.Sleep(750);
                    break;
            }
        }

        private AttackType ChooseAttack()
        {
            string playerChoice = string.Empty;
            Console.Write("Select 1, 2 or 3: ");
            while (true)
            {
                playerChoice = Console.ReadLine();

                int playerChoiceInt = 0;
                bool isNumber = int.TryParse(playerChoice, out playerChoiceInt);

                if (isNumber && playerChoice != string.Empty)
                {
                    switch (playerChoiceInt)
                    {
                        case 1:
                            return AttackType.AttackOne;
                        case 2:
                            return AttackType.AttackTwo;
                        case 3:
                            return AttackType.Heal;
                    }
                }
            }
        }
    }

    public class Game
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        public Game()
        {
            Player = new Player("John McClain", 100);
            Enemy = new Enemy("Hans Gruber", 200);
        }

        public void DisplayCombatInfo()
        {
            Console.WriteLine("John McClain: {0}        Hans Gruber: {1}", this.Player.HP, this.Enemy.HP);
            Console.WriteLine("1) Kick");
            Console.WriteLine("2) Punch");
            Console.WriteLine("3) Shake it off");
        }

        public void PlayGame()
        {
            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {
                DisplayCombatInfo();
                this.Player.Attack(this.Enemy);
                this.Enemy.Attack(this.Player);

                Console.Clear();
            }
            if (this.Player.IsAlive)
            {
                Console.WriteLine("Yippy Kai-Ay Motha Fucka!");
                Console.Beep(659, 125);
                Console.Beep(659, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(523, 125);
                Console.Beep(659, 125);
                Thread.Sleep(125);
                Console.Beep(784, 125);
                Thread.Sleep(375);
                Console.Beep(392, 125);
                Thread.Sleep(375);
                Console.Beep(523, 125);
                Thread.Sleep(250);
                Console.Beep(392, 125);
                Thread.Sleep(250);
                Console.Beep(330, 125);
                Thread.Sleep(250);
                Console.Beep(440, 125);
                Thread.Sleep(125);
                Console.Beep(494, 125);
                Thread.Sleep(125);
                Console.Beep(466, 125);
                Thread.Sleep(42);
                Console.Beep(440, 125);
                Thread.Sleep(125);
                Console.Beep(392, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(125);
                Console.Beep(784, 125);
                Thread.Sleep(125);
                Console.Beep(880, 125);
                Thread.Sleep(125);
                Console.Beep(698, 125);
                Console.Beep(784, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(125);
                Console.Beep(523, 125);
                Thread.Sleep(125);
                Console.Beep(587, 125);
                Console.Beep(494, 125);
                Thread.Sleep(125);
                Console.Beep(523, 125);
                Thread.Sleep(250);
                Console.Beep(392, 125);
                Thread.Sleep(250);
                Console.Beep(330, 125);
                Thread.Sleep(250);
                Console.Beep(440, 125);
                Thread.Sleep(125);
                Console.Beep(494, 125);
                Thread.Sleep(125);
                Console.Beep(466, 125);
                Thread.Sleep(42);
                Console.Beep(440, 125);
                Thread.Sleep(125);
                Console.Beep(392, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(125);
                Console.Beep(784, 125);
                Thread.Sleep(125);
                Console.Beep(880, 125);
                Thread.Sleep(125);
                Console.Beep(698, 125);
                Console.Beep(784, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(125);
                Console.Beep(523, 125);
                Thread.Sleep(125);
                Console.Beep(587, 125);
                Console.Beep(494, 125);
                Thread.Sleep(375);
                Console.Beep(784, 125);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Thread.Sleep(42);
                Console.Beep(622, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(415, 125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Thread.Sleep(125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Console.Beep(587, 125);
                Thread.Sleep(250);
                Console.Beep(784, 125);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Thread.Sleep(42);
                Console.Beep(622, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(698, 125);
                Thread.Sleep(125);
                Console.Beep(698, 125);
                Console.Beep(698, 125);
                Thread.Sleep(625);
                Console.Beep(784, 125);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Thread.Sleep(42);
                Console.Beep(622, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(415, 125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Thread.Sleep(125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Console.Beep(587, 125);
                Thread.Sleep(250);
                Console.Beep(622, 125);
                Thread.Sleep(250);
                Console.Beep(587, 125);
                Thread.Sleep(250);
                Console.Beep(523, 125);
                Thread.Sleep(1125);
                Console.Beep(784, 125);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Thread.Sleep(42);
                Console.Beep(622, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(415, 125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Thread.Sleep(125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Console.Beep(587, 125);
                Thread.Sleep(250);
                Console.Beep(784, 125);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Thread.Sleep(42);
                Console.Beep(622, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(698, 125);
                Thread.Sleep(125);
                Console.Beep(698, 125);
                Console.Beep(698, 125);
                Thread.Sleep(625);
                Console.Beep(784, 125);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Thread.Sleep(42);
                Console.Beep(622, 125);
                Thread.Sleep(125);
                Console.Beep(659, 125);
                Thread.Sleep(167);
                Console.Beep(415, 125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Thread.Sleep(125);
                Console.Beep(440, 125);
                Console.Beep(523, 125);
                Console.Beep(587, 125);
                Thread.Sleep(250);
                Console.Beep(622, 125);
                Thread.Sleep(250);
                Console.Beep(587, 125);
                Thread.Sleep(250);
                Console.Beep(523, 125);
                Thread.Sleep(625);
            }
            else
            {
                Console.WriteLine("You Lose!");
            }
        }
    }
}
