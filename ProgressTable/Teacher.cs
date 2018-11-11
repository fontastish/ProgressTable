using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable
{
    public static class Teacher
    {

        public static Table ReadFileTable(string nameFile)                                  
            // создание информации о кол-ве лаб 
        {
            var n = 0;                                                              // кол-во лаб
            var m = 0;                                                              //кол-во заданий
            StreamReader read = new StreamReader(nameFile + ".txt");                // открываем файл
            n = Int32.Parse(read.ReadLine());                                         //считываем кол-во лаб 
            var strtemp = read.ReadLine();                                          // для хранение второй строки из файла
            string[] arrstr = strtemp.Split(new[] { ' ', ',', '.' });                 // создание массива стринг с заданиями
            int[] arrint = new int[arrstr.Length];
            for (var i = 0; i < arrstr.Length; i++)
            {
                arrint[i] = Int32.Parse(arrstr[i]);
            }
            int[][] arrtable = new int[n][];
            for (var i = 0; i < n; i++)
            {
                arrtable[i] = new int[arrint[i]];
            }

            Table temp = new Table(arrtable);

            return temp;
        }
        public static Student[] ReadFileStudents(string nameFile)
        {
            string strtemp;                                                              // это всё нужно для подсчёта кол-во строк
            var m = 0;
            var read = new StreamReader(nameFile + ".txt");
            while ((strtemp = read.ReadLine()) != null)                                 // я не знаю как посчитать кол-во строк
                m++;
            read.Close();                                                               //тут конец
            var arrstud = new Student[m];                                               //массив с студентами
            var read1 = new StreamReader(nameFile + ".txt");                            //опять поток на тот же файл
            for (var i = 0; i < m; i++)
            {
                var arrstr = read1.ReadLine().Split(' ', ',', '.');                     //читаем строку и делим на имя, фамилия
                arrstud[i] = new Student(new FullName(arrstr[0], arrstr[1]));           // создаем и присваеваем студента 
            }

            return arrstud;                                                             //возращаем массив студентов
        }
    }
}
