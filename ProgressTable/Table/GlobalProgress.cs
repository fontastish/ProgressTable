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
            //var ProgressStudent = string.Empty;
            StringBuilder ProgressStudent = new StringBuilder();
            try
            {
                ProgressStudent.Append(Students[i].Name + " passed");
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
                        ProgressStudent.Append('\n' + k + " lab");

                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (ProgressStudent.ToString().EndsWith("passed"))
                ProgressStudent.Append(" nothing");
            return ProgressStudent.ToString();
        }

        public string ToStringStudents()
        {
            StringBuilder strout = new StringBuilder();
            for (int i = 0; i < Students.Length; i++)
            {
                strout.Append(Students[i].ToString() + "\n");
            }
            strout.Remove(strout.Length - 2, 2);
            return strout.ToString();
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
            StringBuilder strout = new StringBuilder();
            try
            {
               strout.Append(Students[i].ToString() + "\n" + GlobalProgressTable[i].ToString());
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return strout.ToString();

        }

    }
}
