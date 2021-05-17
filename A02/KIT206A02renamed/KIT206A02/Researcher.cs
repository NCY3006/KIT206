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
        //public URL Photo { get; set; } ??
        public string Degree { get; set; }
        public int Supervisor_id { get; set; }
        public enum Level { get; set; }
        public DateTime Utas_start { get; set; }
        public DateTime Current_start { get; set; 
                                       
                                       
        public List<Publication> Skills { get; set; }

        public int SkillCount
        {
            get { return Skills == null ? 0 : Skills.Count(); }
        }

        //The SkillCount out of 10, expressed as a percentage
        public double SkillPercent
        {
            //This is equivalent to SkillCount / 10.0 * 100
            get { return SkillCount * 10.0; }
        }

        //This is likely the solution you will have devised
        public DateTime MostRecentTraining
        {
            get
            {
                var skillDates = from Researcher s in Skills
                                 orderby s.Certified descending
                                 select s.Certified;
                return skillDates.First();
            }
        }


        public override string ToString()
        {
            //For the purposes of this week's demonstration this returns only the name
            return Name;
        }
    }
}
