using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RAP.Research
{

    //As an example, this includes an additional 'EmploymentLevel' called Any that could be used in a GUI drop-down list.
    //The filtering could then be modified that if EmploymentLevel.Any is selected that the full list is returned with no filtering performed.
    public enum EmploymentLevel { Student, A, B, C, D, E }; //These have to equate to a number, it's on the rap sheet

    public class Staff
    {
        
        public float ThreeYearAverage()
        {
            var publicationsTally = 0; //tally for publications of last three years

            if (PublicationYear = Today.year || Today.year - 1 || Today.year - 2) //detects if publication year is within last thres years
            {
                publicationsTally++;
            }

            publicationsTally/3;
            return publicationsTally;
        }

        public double Performance()
        {
            //Make this work
            //three year average/expected number of publications for their employment level
            //expressed as a percentage with one decimal point

            double performancelevel = 0.0;
            double testing = ThreeYearAverage() / EmploymentLevel; //this shouldn't work, just showing how I imagined it

            //can do a switch statement 

            return testing; //change variable testing's name later 

        }

    }
}
