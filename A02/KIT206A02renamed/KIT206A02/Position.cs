using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    
    public class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

       
        public string Title()
        {
            return "Dr";
        }

        public string ToTitle(EmploymentLevel level)
        {
            switch(level)
            {
                case EmploymentLevel.Student:
                    return "Student";
                    break;

                case EmploymentLevel.A:
                    return "Postdoc";
                    break;

                case EmploymentLevel.B:
                    return "Lecturer";
                    break;

                case EmploymentLevel.C:
                    return "Senior Lecturer";
                    break;

                case EmploymentLevel.D:
                    return "Associate Professor";
                    break;

                case EmploymentLevel.E:
                    return "Professor";
                    break;

                default:
                    return "NA";


            }

        }
    }
}
