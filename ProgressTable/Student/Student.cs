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
    }
}