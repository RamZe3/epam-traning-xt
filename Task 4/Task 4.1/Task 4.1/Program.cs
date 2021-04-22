using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class FileManager
    {
        private string reserveDirectory;
        private string directory;
        private string date { get => DateTime.Now.ToString(@"yyyy-MM-dd-HH-mm"); }

        private string indirectory;
        private string outdirectory;

        public FileManager(string directory)
        {
            // TODO try
            this.directory = directory;
            reserveDirectory = Directory.GetDirectoryRoot(directory) +
                 new DirectoryInfo(directory).Name + @"Reserve\";
            Directory.CreateDirectory(reserveDirectory);
        }

        public void CreateReserveDirectory()
        {
            indirectory = directory;
            outdirectory = reserveDirectory + @"\" + date + @"\";
            Directory.CreateDirectory(outdirectory);
            CopyFilesFromDir(indirectory, outdirectory);
            ForeachDirsCopy(indirectory, outdirectory);
        }
        public void ComeBack()
        {
            indirectory = ShowReserveDirs();
            outdirectory = directory;
            CopyFilesFromDir(indirectory, outdirectory);
            ForeachDirsCopy(indirectory, outdirectory);
        }

        private string ShowReserveDirs()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(reserveDirectory);
            var ReserveDirs = directoryInfo.GetDirectories();
            Console.WriteLine("Выберете дату для отката:");
            Console.WriteLine("   Год-Месяц-День-Час-Мин");
            for (int i = 0; i < ReserveDirs.Length; i++)
            {
                Console.WriteLine(i + 1 + ": " + ReserveDirs[i]);
            }

            string str = Console.ReadLine();
            int choice;
            int.TryParse(str, out choice);
            return ReserveDirs[choice - 1].FullName + @"\";
        }

        private void ForeachDirsCopy(string indirectory, string outdirectory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(indirectory);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Directory.CreateDirectory(outdirectory + dir + @"\");
                CopyFilesFromDir(indirectory + dir + @"\", this.outdirectory);
                ForeachDirsCopy(indirectory+ dir +  @"\", outdirectory + dir + @"\");
            }

        }

        private void CopyFilesFromDir(string directory, string outdirectory)
        {
            // TODO EX
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            string dirWithoutMain = directory.Replace(indirectory, "");
            try
            {
                foreach (var file in dirInfo.GetFiles("*.txt"))
                {
                    //Console.WriteLine(outdirectory + dirWithoutMain + file.Name);
                    File.Copy(file.FullName, outdirectory + dirWithoutMain +  file.Name, true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager(@"E:\EpamTestDir\");
            fileManager.CreateReserveDirectory();
            fileManager.ComeBack();

        }
    }
}
