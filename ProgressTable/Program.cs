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
            GlobalProgress tempGlobalProgress = new GlobalProgress("test", "stud");
            for (int i = 0; i < tempGlobalProgress.Students.Length; i++)
            {
                tempGlobalProgress.GlobalProgressTable[i] = WriteData(Table.FileReadTable("test"));
            }

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(GlobalProgress[]));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))                // сохранение файла json
            {
                jsonFormatter.WriteObject(fs, tempGlobalProgress);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                GlobalProgress[] temp = (GlobalProgress[])jsonFormatter.ReadObject(fs);

                //foreach (GlobalProgress p in temp)
                //{
                //    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                //}
            }

            Console.WriteLine(tempGlobalProgress.ToStringByName(new FullName("Asya", "Cat")));
            Console.WriteLine(tempGlobalProgress.ToStringStudents());
            Console.WriteLine(tempGlobalProgress.ToStringProgressForStudent(0));

            Console.WriteLine(tempGlobalProgress.ToString(10));
            Console.ReadKey();      
        }

        //static void WriteData(GlobalProgress temp)
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < temp.GlobalProgressTable.Length; i++)
        //    {
        //        for (int j = 0; j < temp.GlobalProgressTable[i].Progress.Length; j++)
        //        {
        //            for (int k = 0; k < temp.GlobalProgressTable[i].Progress[j].Length; k++)
        //            {
        //                Console.WriteLine("Input mark for task {0} in {1} lab", j, i);
        //                //tempTable.EditData(i, j, int.Parse(Console.ReadLine()));
        //                temp.GlobalProgressTable[i].Progress[j][k].
        //                //(i, j, random.Next(0, 10));
        //            }
        //        }
        //    }
        //}

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
