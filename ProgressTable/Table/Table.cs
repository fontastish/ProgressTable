using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable
{
    public class Table
    {
        public int[][] Progress { get; set; }

        public Table(int [][] progress)
        {
            Progress = progress;
        }

        public void EditData(int lab, int task, int mark)      // редактирование оценки
        {
            Progress[lab][task] = mark;
        }

        public static Table FileReadTable(string nameFile)                                  // создание информации о кол-ве лаб 
        {
            var n = 0;                                                              // кол-во лаб
            var m = 0;                                                              //кол-во заданий
            StreamReader read = new StreamReader(nameFile + ".txt");                // открываем файл
            n = int.Parse(read.ReadLine());                                         //считываем кол-во лаб 
            var strtemp = read.ReadLine();                                          // для хранение второй строки из файла
            string[] arrstr = strtemp.Split(new[] { ' ', ',', '.' });                 // создание массива стринг с заданиями
            int[] arrint = new int[arrstr.Length];
            for (var i = 0; i < arrstr.Length; i++)
            {
                arrint[i] = int.Parse(arrstr[i]);
            }
            int[][] arrtable = new int[n][];
            for (var i = 0; i < n; i++)
            {
                arrtable[i] = new int[arrint[i]];
            }

            Table temp = new Table(arrtable);

            return temp;
        }

        public override string ToString()
         {
            var strout = string.Empty;
            for (int i = 0; i < Progress.Length; i++)
            {
                strout += "Lab " + i + "\n\t";
                for (int j = 0; j < Progress[i].Length; j++)
                {
                    strout += Progress[i][j] + " ";
                }

                strout += "\n";
            }

            return strout;
        }
    }
}