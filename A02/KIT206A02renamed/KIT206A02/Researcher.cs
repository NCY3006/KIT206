using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    /// <summary>
    /// A class baring a striking resemblance to a university researcher
    /// </summary>
    
    // enumerations for the campus and level variables
    public enum Campus { Any, SandyBay, Newnham, Other };
    public enum Level { Any, one, two, three, four };

   
    public class Researcher
    {
        // getters and setters for the researcher class
        public int ID { get; set; }
        public string Given_name { get; set; }
        public string Last_name { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public enum Campus { get; set; }
        public string Email { get; set; }
        public string PhotoURL { get; set; } //public URL Photo { get; set; } ??
        public string Degree { get; set; }
        public int Supervisor_id { get; set; }
        public enum Level { get; set; }
        public DateTime Utas_start { get; set; }
        public DateTime Current_start { get; set; 
                                                                             
        public List<Publication> Skill { get; set; }
        
        //calculate attributes
        public string Current_start { get { return EnumString.Description(CurrentJob); } }
        public double Tenure { get { return DateTime.Today.Subtract(EarliestStart).TotalDays / 365.2425; } }
    }
}
        

