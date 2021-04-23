using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    class Program
    {
        static public void SwitchFileManager(FileManager fileManager)
        {
            Console.WriteLine("Введите опцию:\n");
            Console.WriteLine("1: Наблюдение");
            Console.WriteLine("2: Откат");
            Console.WriteLine("3: Выход");
            string str = Console.ReadLine();
            int.TryParse(str, out int choice);
            switch (choice)
            {
                case 1:
                    fileManager.CreateReserveDirectory();
                    break;
                case 2:
                    fileManager.ComeBack();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Введена некорректная опция!\n");
                    break;
            }
            SwitchFileManager(fileManager);


        }

        static void Main(string[] args)
        {
            Console.WriteLine("FileManager запущен");
            Console.WriteLine("Введите дирректорию: ");
            string str = Console.ReadLine();
            FileManager fileManager = new FileManager(str);
            while (!fileManager.IsCurrentDir)
            {
                str = Console.ReadLine();
                fileManager.ChangeDirectory(str);
            }
            Console.WriteLine("\nFileManager запушен!");
            SwitchFileManager(fileManager);
        }
    }
}
