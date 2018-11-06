using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable
{
    class GlobalProgress
    {
        public Table[] GlobalProgressTable { get; set; }
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
