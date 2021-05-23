using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;

namespace RAP
{
    /// <summary>
    /// A class baring a striking resemblance to a university researcher
    /// </summary>
    
    // enumerations for the campus and level variables



    public class Researcher
    {
        // getters and setters for the researcher class
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string PhotoURL { get; set; } 
        public string Degree { get; set; }
 


        //calculate attributes
        public string GetCurrentJob { get { return EnumString.Description(catagory); } }
        public double Tenure { get { return DateTime.Today.Subtract(EarliestStart).TotalDays / 365.2425; } }

        public DateTime CurrentJobStart { get { return EnumDateTime.Description(current_start); } }

        public Position GetEarlistJob { get { return EnumPosition.Description(start); } }


        public DateTime EarliestStart
        {
            get
            {
                var StartDates = from Researcher s in researcher
                                 orderby s.utas_start descending
                                 select s.utas_start;
                return StartDates.First();
            }
        }
        public int PublicationsCount
        {
            get { return Publication == null ? 0 : Publication.Count(); }
        }
    }
}
        

