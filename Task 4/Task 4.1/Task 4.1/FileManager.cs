using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class FileManager
    {
        private string reserveDirectory;
        private string directory;
        public bool IsCurrentDir {
            get
            {
                return Directory.Exists(directory);
            }
        }
        private string date { get => DateTime.Now.ToString(@"yyyy-MM-dd-HH-mm"); }

        private string indirectory;
        private string outdirectory;

        public FileManager(string directory)
        {
            if (directory[directory.Length-1] != '\\')
            {
                directory += @"\";
            }
            this.directory = directory;

            if (!IsCurrentDir)
            {
                Console.WriteLine("\nВведен некорректный адрес!\n");
            }
            else
            {
                reserveDirectory = Directory.GetDirectoryRoot(directory) +
                 new DirectoryInfo(directory).Name + @"Reserve\";
                Directory.CreateDirectory(reserveDirectory);
            }
        }

        public void ChangeDirectory(string directory)
        {
            if (directory[directory.Length-1] != '\\')
            {
                directory += @"\";
            }
            this.directory = directory;

            if (!IsCurrentDir)
            {
                Console.WriteLine("\nВведен некорректный адрес!\n");
            }
            else
            {
                reserveDirectory = Directory.GetDirectoryRoot(directory) +
                 new DirectoryInfo(directory).Name + @"Reserve\";
                Directory.CreateDirectory(reserveDirectory);
            }
        }

        public void CreateReserveDirectory()
        {
            try
            {
                indirectory = directory;
                outdirectory = reserveDirectory + @"\" + date + @"\";
                Directory.CreateDirectory(outdirectory);
                CopyFilesFromDir(indirectory, outdirectory);
                ForeachDirsCopy(indirectory, outdirectory);
            }
            catch(Exception e)
            {
                Console.WriteLine("\nОшибка исполнения! (Введен некорректный адрес)\n");
            }      
        }

        public void ComeBack()
        {
            try
            {
                indirectory = ShowReserveDirs();

                if (indirectory == null)
                {
                    return;
                }

                outdirectory = directory;
                CopyFilesFromDir(indirectory, outdirectory);
                ForeachDirsCopy(indirectory, outdirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nОшибка исполнения! (Введен некорректный адрес)\n");
            }   
        }

        private string ShowReserveDirs()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(reserveDirectory);
            var ReserveDirs = directoryInfo.GetDirectories();
            Console.WriteLine("Выберете дату для отката:");
            Console.WriteLine("   Год-Месяц-День-Час-Мин");
            Console.WriteLine("0: Выход");
            for (int i = 0; i < ReserveDirs.Length; i++)
            {
                Console.WriteLine(i + 1 + ": " + ReserveDirs[i]);
            }

            string str = Console.ReadLine();
            int.TryParse(str, out int choice);

            if (choice == 0)
            {
                return null;
            }

            try
            {
                return ReserveDirs[choice - 1].FullName + @"\";
            }
            catch(Exception e)
            {
                Console.WriteLine("\nНе существует данного решения!\n");
                return ShowReserveDirs();
            }
        }

        private void ForeachDirsCopy(string indirectory, string outdirectory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(indirectory);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Directory.CreateDirectory(outdirectory + dir + @"\");
                CopyFilesFromDir(indirectory + dir + @"\", this.outdirectory);
                ForeachDirsCopy(indirectory + dir + @"\", outdirectory + dir + @"\");
            }

        }

        private void CopyFilesFromDir(string directory, string outdirectory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            string dirWithoutMain = directory.Replace(indirectory, "");

            foreach (var file in dirInfo.GetFiles("*.txt"))
            {
                File.Copy(file.FullName, outdirectory + dirWithoutMain + file.Name, true);
            }
        }
    }
}
