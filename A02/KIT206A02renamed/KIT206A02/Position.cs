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
            //Make this work
        }

        public string ToTitle(EmploymentLevel)
        {
            //Make this work
        }
    }
}
