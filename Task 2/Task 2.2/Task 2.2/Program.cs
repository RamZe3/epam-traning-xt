using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task_2._2
{ 
    // TODO creator
    public class Game
    {
        GameObject[] gameObjects;
        int countOfGO;

        PlayingField playingField = new PlayingField(20);
        GamePlay gamePlay = new GamePlay();
        public Game()
        {
            // first GO in mass always Player
            this.gameObjects = new GameObject[5];
            this.countOfGO = 5;
            gameObjects[0] = new Player(5, 5);
            gameObjects[1] = new Enemy(4, 5, EnemyType.Lying);
            gameObjects[2] = new Bonus(3, 5, BonusType.Cherry);
            gameObjects[3] = new Block(10, 10);
            gameObjects[4] = new Enemy(9, 9, EnemyType.Standing);
        }

        public void Play()
        {
            gamePlay.Start();
            while (true)
            {
                playingField.ArrangementObjOnField(this.gameObjects, this.countOfGO);
                Console.WriteLine(playingField.ToString());

                if(gamePlay.CheckTwoGameObjPosition(gameObjects[0], gameObjects[1]))
                {
                    gamePlay.Lose();
                    break;
                }
                if (gamePlay.CheckTwoGameObjPosition(gameObjects[0], gameObjects[4]))
                {
                    gamePlay.Lose();
                    break;
                }
                if (gamePlay.CheckTwoGameObjPosition(gameObjects[0], gameObjects[3]))
                {
                    gameObjects[0].x = gameObjects[0].lastPosition.x;
                    gameObjects[0].y = gameObjects[0].lastPosition.y;
                }
                if (gamePlay.CheckTwoGameObjPosition(gameObjects[1], gameObjects[3]))
                {
                    gameObjects[1].x = gameObjects[1].lastPosition.x;
                    gameObjects[1].y = gameObjects[1].lastPosition.y;
                }
                if (gamePlay.CheckTwoGameObjPosition(gameObjects[0], gameObjects[2]))
                {
                    gamePlay.Win();
                    break;
                }

                string str = Console.ReadKey().KeyChar.ToString();
                //Console.WriteLine(str);
                switch (str)
                {
                    case "w":
                        this.gameObjects[0].move(2);
                        
                        break;
                    case "s":
                        this.gameObjects[0].move(1);
                        break;
                    case "a":
                        this.gameObjects[0].move(4);
                        break;
                    case "d":
                        this.gameObjects[0].move(3);
                        break;
                }
                

                this.gameObjects[1].move();
                this.gameObjects[4].move();
                Console.WriteLine(gameObjects[0].lastPosition.x + " " + gameObjects[0].lastPosition.x);
                //Thread.Sleep(5000);
                playingField.ClearField();
                Console.Clear();
            }
        }
    }
    
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point()
        {

        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    abstract public class GameObject : Point
    {
        public Point lastPosition = new Point();
        public string strValue;
        public virtual void move() {
        }
        public virtual void move(int controler)
        {
        }
    }

    public class GamePlay
    {
        public bool CheckTwoGameObjPosition(GameObject gm1, GameObject gm2)
        {
            if (gm1.x == gm2.x && gm1.y == gm2.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Start()
        {
            Console.WriteLine("Цель игры собрать все бонусы\n" +
                "Управление WASD (Внимательнее с раскладкой)\n" +
                "Косание врага - проигрыш\n" +
                "Подбор бонуса - выйгрыш");
            Thread.Sleep(4000);
        }

        public void Win()
        {
            Console.WriteLine("U are Win)");
        }

        public void Lose()
        {
            Console.WriteLine("U are lose)");
        }
    }

    public class PlayingField
    {
        public GameObject[] gameObjects = new GameObject[100];
        public string[] field;
        public int dimension;

        public PlayingField(int dimension)
        {
            this.dimension = dimension;
            this.field = new string[dimension];
            for (int i = 0; i < dimension; i++)
            {
                field[i] = new string(' ', field.Length);
            }
        }

        public void ClearField()
        {
            for (int i = 0; i < dimension; i++)
            {
                field[i] = new string(' ', field.Length);
            }
        }

        public void ArrangementObjOnField(GameObject[] gameObjects, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (gameObjects[i].x <1)
                {
                    gameObjects[i].x = 1;
                }
                else if (gameObjects[i].x > this.dimension-1)
                {
                    gameObjects[i].x = this.dimension - 2;
                }

                if (gameObjects[i].y < 1)
                {
                    gameObjects[i].y = 1;
                }
                else if (gameObjects[i].y > this.dimension-1)
                {
                    gameObjects[i].y = this.dimension - 2;
                }
                this.field[gameObjects[i].y] = this.field[gameObjects[i].y].Insert(gameObjects[i].x, gameObjects[i].strValue);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < field.Length; i++)
            {
                sb.Append(field[i] + "|\n");
            }
            return sb.ToString();
        }
    }

    public class Player : GameObject
    {
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.lastPosition.x = x;
            this.lastPosition.x = y;
            this.strValue = "*";
        }

        public override void move(int controler)
        {
            this.lastPosition.x = this.x;
            this.lastPosition.y = this.y;
            switch (controler)
            {
                case 1:
                    this.y += 1;
                    break;
                case 2:
                    this.y -= 1;
                    break;
                case 3:
                    this.x += 1;
                    break;
                case 4:
                    this.x -= 1;
                    break;

            }
        }
    }

    public class Enemy : GameObject
    {
        Random random = new Random();
        public Enemy(int x, int y, EnemyType enemyType)
        {
            this.x = x;
            this.y = y;
            lastPosition.x = x;
            lastPosition.y = y;
            switch (enemyType)
            {
                case EnemyType.Standing:
                    this.strValue = "|";
                    break;
                case EnemyType.Lying:
                    this.strValue = "_";
                    break;
                default:
                    this.strValue = "E";
                    break;
            }
        }

        public override void move()
        {
            lastPosition.x = this.x;
            lastPosition.y = this.y;
            this.x += this.random.Next(-1, 2);
            this.y += this.random.Next(-1, 2);
        }
    }

    public enum EnemyType
    {
        None = 0,
        Standing = 1,
        Lying = 2,
    }

    public class Bonus : GameObject
    {
        public Bonus(int x, int y, BonusType bonusType)
        {
            this.x = x;
            this.y = y;
            switch (bonusType)
            {
                case BonusType.Apple:
                    this.strValue = "A";
                    break;
                case BonusType.Cherry:
                    this.strValue = "C";
                    break;
                case BonusType.Pear:
                    this.strValue = "P";
                    break;
                default:
                    this.strValue = "B";
                    break;
            }
        }
    }

    public enum BonusType
    {
        None = 0,
        Apple = 1,
        Pear = 2,
        Cherry = 3,
    }

    public class Block : GameObject
    {
        public Block(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.strValue = "❌";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}
