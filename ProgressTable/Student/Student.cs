using System.IO;
using System.Runtime.Serialization;

namespace ProgressTable
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public FullName Name { get; set; }
        //  public int Number { get; set; }

        public Student(FullName name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public static Student[] FileReadStudents(string nameFile)
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