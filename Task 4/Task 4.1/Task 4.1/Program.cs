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
            /*
            //reserveDirectoryWithDate = reserveDirectory + @"\" + GetDate();
            CopyFilesFromDir(directory);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Directory.CreateDirectory(reserveDirectory + dir + @"\");
                CopyFilesFromDir(directory + dir + @"\");
            }*/

            reserveDirectoryWithDate = reserveDirectory + @"\" + GetDate() + @"\";
            Directory.CreateDirectory(reserveDirectoryWithDate);
            CopyFilesFromDir(directory);
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Directory.CreateDirectory(reserveDirectoryWithDate + dir + @"\");
                CopyFilesFromDir(directory + dir + @"\");
            }

        }

        private void CopyFilesFromDir(string directory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            string dirWithoutMain = directory.Replace(this.directory, "");
            try
            {
                foreach (var file in dirInfo.GetFiles("*.txt"))
                {
                    File.Copy(file.FullName, reserveDirectoryWithDate + dirWithoutMain +  file.Name, true);
                    //File.Copy(file.FullName, reserveDirectory + dirWithoutMain +  file.Name, true);
                    //Console.WriteLine(file.DirectoryName);
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
            string dir = @"E:\EpamTestDir\";

            var dir_ = Directory.GetFiles(dir);
            var dir__ = Directory.GetDirectories(dir);
            var asd = Directory.GetFileSystemEntries(dir);
            Console.WriteLine(dir__[0]);
            foreach (var file in dir_)
            {
                //Console.WriteLine(File.ReadAllText(file));
                // TODO
                Console.WriteLine(file);
                Console.WriteLine(Path.GetFileName(file));
                Console.WriteLine(Path.GetExtension(file));
            }
            Console.WriteLine();
            foreach (var dir1 in dir__)
            {
                Console.WriteLine(dir1);
                DirectoryInfo directoryInfo = new DirectoryInfo(dir1);
                Console.WriteLine(Directory.GetDirectoryRoot(dir1));
                Console.WriteLine(directoryInfo.Name);
                //Console.WriteLine(Path.GetDirectoryName(dir1));
                Console.WriteLine();
            }
            //var str = File.ReadAllText(path);
            //Console.WriteLine(str);
            FileManager fileManager = new FileManager(dir);
            //fileManager.CopyFiles();
            Console.WriteLine('\n');
            fileManager.CreateReserveDirectory();
            Console.WriteLine('\n');
            Console.WriteLine(Directory.GetAccessControl(dir));

            string ert = "asdqasd";
            string asdf = ert.Replace("asdq", "");
            Console.WriteLine(asdf);
            Console.WriteLine();
            Console.WriteLine(fileManager.GetDate());

        }
    }
}
