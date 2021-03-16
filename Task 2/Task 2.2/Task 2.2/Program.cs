using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task_2._2
{
    
    public class Game
    {
        GameObject[] gameObjects;
        int count;
        PlayingField playingField = new PlayingField();
        public Game()
        {
            this.gameObjects = new GameObject[5];
            this.count = 3;
            gameObjects[0] = new Player(5, 5);
            gameObjects[1] = new Enemy(3, 3);
            gameObjects[2] = new Bonus(3, 5);
        }

        public void Play()
        {
            while (true)
            {
                playingField.ArrangementObjOnField(this.gameObjects, this.count);
                Console.WriteLine(playingField.ToString());
                this.gameObjects[1].move();
                Console.WriteLine(this.gameObjects[1].x);
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
        public bool CheckPlayerAndEnemyPosition(Player player, Enemy enemy)
        {
            if (player.x == enemy.x && player.y == enemy.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPlayerAndBonusPosition(Player player, Bonus bonus)
        {
            if (player.x == bonus.x && player.y == bonus.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class PlayingField
    {
        public GameObject[] gameObjects = new GameObject[100];
        public string[] field = new string[10];

        public PlayingField()
        {
            for (int i = 0; i < 10; i++)
            {
                field[i] = new string(' ', field.Length);
            }
        }

        public void ClearField()
        {
            for (int i = 0; i < 10; i++)
            {
                field[i] = new string(' ', field.Length);
            }
        }

        public void ArrangementObjOnField(GameObject[] gameObjects, int count)
        {
            for (int i = 0; i < count; i++)
            {
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
        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.strValue = "|";
        }

        public override void move()
        {
            this.x += random.Next(-1, 2);
            this.y += random.Next(-1, 2);
        }
    }

    public class Bonus : GameObject
    {
        public Bonus(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.strValue = "B";
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
