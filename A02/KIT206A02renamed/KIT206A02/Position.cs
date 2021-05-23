using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;

namespace RAP
{
    
    public class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

       
        public string Title(Researcher)
        {
             string personsTitle = 
             from title in researcher
             where Researcher = researcher
             return personsTitle; 

        }

        public string ToTitle(EmploymentLevel level)
        {
            switch(level)
            {
                case EmploymentLevel.Student:
                    return "Student";

                case EmploymentLevel.A:
                    return "Postdoc";

                case EmploymentLevel.B:
                    return "Lecturer";

                case EmploymentLevel.C:
                    return "Senior Lecturer";

                case EmploymentLevel.D:
                    return "Associate Professor";

                case EmploymentLevel.E:
                    return "Professor";

                default:
                    return "NA";


            }

        }
    }
}
