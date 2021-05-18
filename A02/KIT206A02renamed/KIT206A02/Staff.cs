using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{

    //As an example, this includes an additional 'EmploymentLevel' called Any that could be used in a GUI drop-down list.
    //The filtering could then be modified that if EmploymentLevel.Any is selected that the full list is returned with no filtering performed.
    public enum EmploymentLevel { Student, A, B, C, D, E };

    /// <summary>
    /// A class baring a striking resemblance to a university researcher
    /// </summary>
    public class Staff
    {
        
        public float ThreeYearAverage()
        {
            //Make this work
        }

        public float Performance()
        {
            //Make this work
        }

    }
}
