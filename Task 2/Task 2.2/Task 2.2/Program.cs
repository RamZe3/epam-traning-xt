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
            this.gameObjects = new GameObject[5];
            this.countOfGO = 4;
            gameObjects[0] = new Player(5, 5);
            gameObjects[1] = new Enemy(4, 5, EnemyType.Lying);
            gameObjects[2] = new Bonus(3, 5, BonusType.Cherry);
            gameObjects[3] = new Block(4, 4);
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
                this.gameObjects[1].move();

                Thread.Sleep(500);
                playingField.ClearField();
                Console.Clear();
            }
        }
    }
    abstract public class GameObject
    {
        public int x { get; set; }
        public int y { get; set; }
        public string strValue;
        public virtual void move() {
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
            Console.WriteLine("Цель игры собрать все бонусы");
            Thread.Sleep(3000);
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
                sb.Append(field[i] + "\n");
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
            this.strValue = "*";
        }

        public  void move(int controler)
        {
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
            this.x += random.Next(-1, 2);
            this.y += random.Next(-1, 2);
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
            /*
            GameObject[] gameObjects = new GameObject[5];
            int count = 3;
            gameObjects[0] = new Player(5, 5);
            gameObjects[1] = new Enemy(3,3);
            gameObjects[2] = new Bonus(3, 5);
            //Console.WriteLine(gameObjects[0].x);
            PlayingField playingField = new PlayingField();
            playingField.ArrangementObjOnField(gameObjects, count);
            Console.WriteLine(playingField.ToString());*/
        }
    }
}
