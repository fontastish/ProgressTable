using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            Console.WriteLine(tempGlobalProgress.ToStringByName(new FullName("Asya", "Cat")));
            Console.WriteLine(tempGlobalProgress.ToStringStudents());
            Console.WriteLine('\u2713');

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
