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
            StringBuilder strout = new StringBuilder();
            for (int i = 0; i < Progress.Length; i++)
            {
                strout.Append("-----------\n");
                strout.Append("Lab " + (i+1).ToString() + "\n\t");
                for (int j = 0; j < Progress[i].Length; j++)
                {
                    strout.Append(Progress[i][j] + " ");
                }

                strout.Append("\n");
            }

            return strout.Remove(strout.Length-2,2).ToString();
        }
    }
}