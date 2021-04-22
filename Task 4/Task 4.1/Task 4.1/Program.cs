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
        private DirectoryInfo directoryInfo;
        private string reserveDirectory;
        private string reserveDirectoryWithDate;
        private string indirectory;
        public string directory { get; set; }
        public FileManager(string directory)
        {
            // TODO try
            directoryInfo = new DirectoryInfo(directory);
            this.directory = directory;
            //directoryFiles = Directory.GetFiles(directory);

            reserveDirectory = Directory.GetDirectoryRoot(directory) +
                directoryInfo.Name + @"Reserve\";
            Directory.CreateDirectory(reserveDirectory);
        }

        public string GetDate()
        {
            return DateTime.Now.ToString(@"yyyy-MM-dd-HH-mm");
        }

        public void CreateReserveDirectory()
        {
            indirectory = directory;
            reserveDirectoryWithDate = reserveDirectory + @"\" + GetDate() + @"\";
            Directory.CreateDirectory(reserveDirectoryWithDate);
            CopyFilesFromDir(directory, reserveDirectoryWithDate);
            ForeachDirsCopy(directory, reserveDirectoryWithDate, reserveDirectoryWithDate);
        }

        public void ForeachDirsCopy(string indirectory, string outdirectory, string mainoutdirectory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(indirectory);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Directory.CreateDirectory(outdirectory + dir + @"\");
                CopyFilesFromDir(indirectory + dir + @"\", mainoutdirectory);
                ForeachDirsCopy(indirectory+ dir +  @"\", outdirectory + dir + @"\", mainoutdirectory);
            }

        }

        public void CopyFilesFromDir(string directory, string outdirectory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            string dirWithoutMain = directory.Replace(indirectory, "");
            try
            {
                foreach (var file in dirInfo.GetFiles("*.txt"))
                {
                    Console.WriteLine(outdirectory + dirWithoutMain + file.Name);
                    File.Copy(file.FullName, outdirectory + dirWithoutMain +  file.Name, true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ComeBack_()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(reserveDirectory);
            int count = 1;
            Console.WriteLine("Выберете дату копирования:");
            Console.WriteLine("   Год-Месяц-День-Час-Мин");
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Console.WriteLine( count + ": " + dir);
                count++;
            }
        }

        public void ComeBack(string nameOfDir)
        {
            indirectory = nameOfDir;
            reserveDirectoryWithDate = nameOfDir;
            CopyFilesFromDir(reserveDirectoryWithDate, directory);
            ForeachDirsCopy(reserveDirectoryWithDate, directory, directory);
        }



    }



    class Program
    {
        static void Main(string[] args)
        {
            string dir = @"E:\EpamTestDir\";

            var dir_ = Directory.GetFiles(dir);
            var dir__ = Directory.GetDirectories(dir);
            var asd = Directory.GetFileSystemEntries(dir);
            //Console.WriteLine(dir__[0]);
            foreach (var file in dir_)
            {
                //Console.WriteLine(File.ReadAllText(file));
                // TODO
                //Console.WriteLine(file);
                //Console.WriteLine(Path.GetFileName(file));
                //Console.WriteLine(Path.GetExtension(file));
            }
            //Console.WriteLine();
            foreach (var dir1 in dir__)
            {
                //Console.WriteLine(dir1);
                DirectoryInfo directoryInfo = new DirectoryInfo(dir1);
                //Console.WriteLine(Directory.GetDirectoryRoot(dir1));
                //Console.WriteLine(directoryInfo.Name);
                //Console.WriteLine(Path.GetDirectoryName(dir1));
                Console.WriteLine();
            }
            //var str = File.ReadAllText(path);
            //Console.WriteLine(str);
            FileManager fileManager = new FileManager(dir);
            //fileManager.CopyFiles();
            //Console.WriteLine('\n');
            //Console.WriteLine('\n');
            //Console.WriteLine(Directory.GetAccessControl(dir));

            fileManager.CreateReserveDirectory();



            string ert = "asdqasd";
            string asdf = ert.Replace("asdq", "");
            //Console.WriteLine(asdf);
            //Console.WriteLine();
            //Console.WriteLine(fileManager.GetDate());
            //fileManager.ComeBack_();
            //fileManager.CopyFilesFromDir(@"E:\EpamTestDirReserve\2021-04-22-21-12\", @"E:\EpamTestDir\");
            //fileManager.ComeBack(@"E:\EpamTestDirReserve\2021-04-22-21-34\");

        }
    }
}
