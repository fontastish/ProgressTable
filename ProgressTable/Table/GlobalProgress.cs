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
            Students = Teacher.ReadFileStudents(student);
            GlobalProgressTable = new Table[Students.Length];
            var temp = Teacher.ReadFileTable(table);
            for (int i = 0; i < GlobalProgressTable.Length; i++)
            {
                GlobalProgressTable[i] = temp;
            }

        }

        public string ToStringProgressForStudent(int i)
        {
            var ProgressStudent = string.Empty;
            try
            {
                ProgressStudent = Students[i].Name + " passed" + "\n";
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
                        ProgressStudent += k + " lab" + "\n";

                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ProgressStudent;
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
