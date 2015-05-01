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
            //create a new object of the game
            Game game = new Game();
            //play the game
            game.PlayGame();

            Console.ReadKey();
        }
    }

    //create an abstract class that all players will have
    public abstract class Actor
    {
        //set up properties
        //name
        public string Name { get; set; }
        //Hit Points
        public int HP { get; set; }
        //read only propertiy just to check if the player is alive
        public bool IsAlive
        {
            get
            {
                return this.HP > 0;
            }
        }

        //constructor to set the properties
        public Actor(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        //a function that can be overwritten
        public virtual void Attack(Actor actor) { }
    }

    //create a class for enemy inheriting from the actor class
    public class Enemy : Actor
    {
        //build the constuctor for the enemy class
        public Enemy(string name, int hp)
            : base(name, hp) { }

        //override the attack function
        public override void Attack(Actor actor)
        {
            //create a random number generator
            Random rng = new Random();
            //grab a number between 1 and 10
            int probabilityOfEnemyHit = rng.Next(1, 11);

            //hit 80% of the time
            if (probabilityOfEnemyHit < 9)
            {
                //remove health from the enemy
                actor.HP -= rng.Next(5, 16);
                Console.WriteLine("Hans managed to land a hit somehow");
                Thread.Sleep(1000);
            }
            //if hit misses
            else
            {
                Console.WriteLine("Hans was no match for your skills");
                Thread.Sleep(1000);
            }
        }
    }

    //create a class for the player inheriting from the actor class
    public class Player : Actor
    {
        //create an enum for the attack type
        public enum AttackType
        {
            AttackOne = 1,
            AttackTwo,
            Heal
        }

        //set the properties for the player
        public Player(string name, int hp)
            : base(name, hp) { }

        //override the attack function
        public override void Attack(Actor actor)
        {
            Random rng = new Random();
            AttackType attack = ChooseAttack();
            int probabilityOfAttack = 0;
            switch (attack)
            {
                //for first attack type
                case AttackType.AttackOne:
                    probabilityOfAttack = rng.Next(1, 11);
                    //hits 70% of the time
                    if (probabilityOfAttack < 8)
                    {
                        actor.HP -= rng.Next(20, 36);
                        Console.WriteLine("You hit Hans square in the noggin");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Your kicking skills were not up to par");
                        Thread.Sleep(1000);
                    }
                    break;
                    //for second attack type
                case AttackType.AttackTwo:
                    actor.HP -= rng.Next(10, 16);
                    Console.WriteLine("Body Blow!");
                    Thread.Sleep(1000);
                    break;
                    //to heal
                case AttackType.Heal:
                    this.HP += rng.Next(10, 21);
                    Console.WriteLine("You became more BadAss");
                    Thread.Sleep(1000);
                    break;
            }
        }

        //function to choose the attack
        private AttackType ChooseAttack()
        {
            string playerChoice = string.Empty;
            Console.Write("Select 1, 2 or 3: ");
            while (true)
            {
                playerChoice = Console.ReadLine();

                int playerChoiceInt = 0;
                //check if input is a number
                bool isNumber = int.TryParse(playerChoice, out playerChoiceInt);

                //check if the input is a number and not an empty string
                if (isNumber && playerChoice != string.Empty)
                {
                    switch (playerChoiceInt)
                    {
                            //if player chooses 1
                        case 1:
                            return AttackType.AttackOne;
                        //if player chooses 2
                        case 2:
                            return AttackType.AttackTwo;
                        //if player chooses 3
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

        //set the player and the enemy
        public Game()
        {
            Player = new Player("John McClane", 100);
            Enemy = new Enemy("Hans Gruber", 200);
        }

        //display the game
        public void DisplayCombatInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: {1}        {2}: {3}\n\n",this.Player.Name, this.Player.HP, this.Enemy.Name, this.Enemy.HP);
            Console.WriteLine("1) Kick");
            Console.WriteLine("2) Punch");
            Console.WriteLine("3) Shake it off");
        }

        //play the game
        public void PlayGame()
        {
            StartGame();
            //while the player and the enemy are alive
            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {
                DisplayCombatInfo();
                this.Player.Attack(this.Enemy);
                this.Enemy.Attack(this.Player);

                Console.Clear();
            }
            //if player won
            if (this.Player.IsAlive)
            {
                Console.WriteLine("Yippy Kai-Ay Motha Fucka!");
                WinSong();
            }
            //if player lost
            else
            {
                Console.WriteLine("You Died Hard!");
            }
        }

        //song for winning
        public void WinSong()
        {
            Console.Beep(587, 125);
            Console.Beep(587, 125);
            Console.Beep(587, 125);
            Console.Beep(587, 500);
            Console.Beep(466, 500);
            Console.Beep(523, 500);
            Console.Beep(587, 250);
            Console.Beep(523, 250);
            Console.Beep(587, 500);
        }

        //display for the start of the game
        public void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(@"▓█████▄  ██▓▓█████     ██░ ██  ▄▄▄       ██▀███  ▓█████▄  ▐██▌ ");
            Console.WriteLine(@"▒██▀ ██▌▓██▒▓█   ▀    ▓██░ ██▒▒████▄    ▓██ ▒ ██▒▒██▀ ██▌ ▐██▌ ");
            Console.WriteLine(@"░██   █▌▒██▒▒███      ▒██▀▀██░▒██  ▀█▄  ▓██ ░▄█ ▒░██   █▌ ▐██▌ ");
            Console.WriteLine(@"░▓█▄   ▌░██░▒▓█  ▄    ░▓█ ░██ ░██▄▄▄▄██ ▒██▀▀█▄  ░▓█▄   ▌ ▓██▒ ");
            Console.WriteLine(@"░▒████▓ ░██░░▒████▒   ░▓█▒░██▓ ▓█   ▓██▒░██▓ ▒██▒░▒████▓  ▒▄▄  ");
            Console.WriteLine(@" ▒▒▓  ▒ ░▓  ░░ ▒░ ░    ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░ ▒▒▓  ▒  ░▀▀▒ ");
            Console.WriteLine(@" ░ ▒  ▒  ▒ ░ ░ ░  ░    ▒ ░▒░ ░  ▒   ▒▒ ░  ░▒ ░ ▒░ ░ ▒  ▒  ░  ░ ");
            Console.WriteLine(@" ░ ░  ░  ▒ ░   ░       ░  ░░ ░  ░   ▒     ░░   ░  ░ ░  ░     ░ ");
            Console.WriteLine(@"   ░     ░     ░  ░    ░  ░  ░      ░  ░   ░        ░     ░    ");
            Console.WriteLine(@" ░                                                ░            ");
            Console.WriteLine("\nPress Any Key To Continue:");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
