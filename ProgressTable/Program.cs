using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "============================";

            DataContractJsonSerializer
                jsonFormatter =
                    new DataContractJsonSerializer(typeof(GlobalProgress)); // создания класса для сериализации

            GlobalProgress tempGlobalProgress;

            if (System.IO.File.Exists("GlobalProgress.json"))
                using (FileStream fs = new FileStream("GlobalProgress.json", FileMode.Open)) // если файл уже создан, то читаем     
                    tempGlobalProgress = (GlobalProgress) jsonFormatter.ReadObject(fs);
            else
            {
                tempGlobalProgress = new GlobalProgress("test", "stud"); // иначе создаём 
                for (int i = 0; i < tempGlobalProgress.Students.Length; i++)
                    tempGlobalProgress.GlobalProgressTable[i] = WriteData(Teacher.ReadFileTable("test"));

            }

            using (FileStream fs = new FileStream("GlobalProgress.json", FileMode.OpenOrCreate))   // записываем файл сериализации
                jsonFormatter.WriteObject(fs, tempGlobalProgress);


            Console.WriteLine(tempGlobalProgress.ToStringStudents());
            Console.WriteLine(line);
            Console.WriteLine(tempGlobalProgress.ToStringProgressForStudent(1));
            Console.WriteLine(line);
            Console.WriteLine(tempGlobalProgress.ToString(2));

            Console.ReadKey();
        }

        static Table WriteData(Table tempTask)
        {
            Random random = new Random();
            for (int i = 0; i < tempTask.Progress.Length; i++)
            {
                for (int j = 0; j < tempTask.Progress[i].Length; j++)
                {
                    //Console.WriteLine("Input mark for task {0} in {1} lab", j, i);
                    tempTask.Progress[i][j] = random.Next(0, 5);
                }
            }

            return tempTask;
        }
    }
}
