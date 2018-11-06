using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgressTable
{
    [DataContract]
    class GlobalProgress
    {
        [DataMember]
        public Table[] GlobalProgressTable { get; set; }
        [DataMember]
        public Student[] Students { get; set; }

        public GlobalProgress(string table, string student)
        {
            Students = Student.FileReadStudents(student);
            GlobalProgressTable = new Table[Students.Length];
            var temp = Table.FileReadTable(table);
            for (int i = 0; i < GlobalProgressTable.Length; i++)
            {
                GlobalProgressTable[i] = temp;
            }

        }

        //public string ToStringProgressForStudent(int i)
        //{
        //    var strout = string.Empty;
        //    strout = GlobalProgressTable[i].ToString();
        //    return strout.Replace('2', '#').Replace('3', '#').Replace('4', '#').Replace('5', '#');
        //}

        public string ToStringProgressForStudent(int i)
        {
            var strout = Students[i].Name + " passed" + "\n";

            for (int k = 0; k < GlobalProgressTable[i].Progress.Length; k++)
            {
                bool check = true;
                for (int l = 0; l < GlobalProgressTable[i].Progress[k].Length; l++)
                {
                    if (GlobalProgressTable[i].Progress[k][l] < 2)
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                    strout += k + " lab" + "\n";

            }

            return strout;
        }

        public string ToStringStudents()
        {
            var strout = string.Empty;
            for (int i = 0; i < Students.Length; i++)
            {
                strout += Students[i].ToString() + "\n";
            }

            return strout;
        }

        public string ToStringByName(FullName name)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Name.Equals(name))
                    return ToString(i);
            }

            return "Not found student with same name";
        }

        public string ToString(int i)
        {
            var strout = string.Empty;
            try
            {
               strout =  Students[i].ToString() + "\n" + GlobalProgressTable[i].ToString();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return strout;

        }

    }
}
