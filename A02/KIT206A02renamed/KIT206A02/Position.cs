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
        public List<Researcher> Type { get; set; }

        //Title will return the persons title eg: "DR, Miss"
        public string Title
        {
            get {
                string personsTitle =
                from Researcher in Type
                where Type = researcher
                return personsTitle;

                 }
        }
        //ToTile will return the name of thier employment based on thier level
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
