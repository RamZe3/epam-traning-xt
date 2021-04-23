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
        static void Main(string[] args)
        {
            // with Ex
            FileManager fileManager = new FileManager(@"фE:\EpamTestDir\");
            fileManager.CreateReserveDirectory();
            fileManager.ComeBack();

            // main

            fileManager.ChangeDirectory(@"E:\EpamTestDir\");
            fileManager.CreateReserveDirectory();
            fileManager.ComeBack();

        }
    }
}
