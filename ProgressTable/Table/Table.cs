using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable
{
    [DataContract]
    public class Table
    {
        [DataMember]
        public int[][] Progress { get; set; }

        public Table(int [][] progress)
        {
            Progress = progress;
        }

        public void EditMark(int lab, int task, int mark)      // редактирование оценки
        {
            Progress[lab][task] = mark;
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