using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTable
{
    public class FullName
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public FullName(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public override string ToString()
        {
            return (FirstName + " " + SecondName);
        }

        public override bool Equals(object obj)
        {
            if (FirstName == ((FullName)obj).FirstName)
                if (SecondName == ((FullName) obj).SecondName)
                    return true;
            return false;
        }
    }
}
