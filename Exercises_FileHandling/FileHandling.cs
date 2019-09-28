using System;
using System.IO;
using System.Linq;

namespace Exercises_FileHandling
{
    public class FileHandling
    {
        static void Main(string[] args)
        {
            
        }

        public static bool  BlankFile(string fileName)
        {
            //Write a program in C# Sharp to create a blank file in the disk newly.
            string[] fileProp = FileProperties(fileName);
            FileStream fs;

            string path = fileProp[0];
            fileName = fileProp[1];
            
            if(!File.Exists(path))
               fs = File.Create(path);

            return File.Exists(path)? true : false;
        }

        public static bool DeleteFile(string fileName)
        {
            //Write a program in C# Sharp to remove a file from the disk.
            string[] fileProp = FileProperties(fileName);
            string path = fileProp[0];
            fileName = fileProp[1];

            if(File.Exists(path))
                File.Delete(path);

            return !File.Exists(path) ? true : false;
        }

        public static bool CreateSecondFile(string fileName)
        {
            //Write a program in C# Sharp to create a blank file in the disk if the same file already exists.
            string[] fileProp = FileProperties(fileName);
            string path = fileProp[0];
            fileName = fileProp[1];
            int[] nums = Enumerable.Range(0, 10).ToArray();
            int index = -1;
            string fileNum = "";

            File.Create(path);

            if (File.Exists(path))
            {
                foreach(int num in nums)
                {
                    if (fileName.Contains(num.ToString()))
                    {                        
                        //assuming number only at the end
                        index = path.IndexOf(num.ToString());
                        fileNum = path.Substring(index, path.LastIndexOf('.')-index);
                        fileNum = (int.Parse(fileNum) + 1).ToString();
                        break;
                    }
                    if (num == 9 && index == -1)
                    {
                        fileNum = 1.ToString();
                        index = -2;
                    }
                }

                if ((index == -2))
                {
                    path = path.Insert(path.LastIndexOf('.'), fileNum);
                    //Console.WriteLine(path);
                    FileStream fs = File.Create(path);
                }
                else if (!(index == -1))
                {
                    path = path.Remove(index, path.LastIndexOf('.')-index).Insert(path.LastIndexOf('.') - 1, fileNum);
                    //Console.WriteLine(path);
                    FileStream fs = File.Create(path);
                }
            }
            else
            {
                Console.WriteLine("Write");
            }

            return File.Exists(path) ? true : false;
        }

        public static string[] FileProperties(string fileName)
        {
            string path;
            int tokens;
            string[] fileProp = new string[2];

            //Write a program in C# Sharp to create a blank file in the disk newly.
            //if the user includes path to save file
            if (fileName.Contains("\\")) 
            {
                tokens = fileName.Split("\\", StringSplitOptions.RemoveEmptyEntries).Length; //determine index to split the fileName
                path = fileName;
                fileName = fileName.Split("\\", StringSplitOptions.RemoveEmptyEntries).GetValue(tokens - 1).ToString().Trim(); //trim white space
            }
            else
            {
                path = @"../../../"; //save in the same file as the solution
            }

            if (!fileName.EndsWith(".txt"))
            {
                fileName = fileName + ".txt";
                path += ".txt";
            }

            fileProp[0] = path;
            fileProp[1] = fileName;

            return fileProp;
        }

        public static bool WriteToFile(string fileName, string message)
        {
            //Write a program in C# Sharp to create a file and add some text.
            string[] fileProp = FileProperties(fileName);
            string path = fileProp[0];
            fileName = fileProp[1];

            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);

                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine(message.Trim());
                writer.Close();
            }

            return File.Exists(path) ? true : false;
        }
        
    }
}
