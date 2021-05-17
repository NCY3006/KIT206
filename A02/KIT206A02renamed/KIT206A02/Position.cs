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
    public class Position
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
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
        public DateTime StartDate
        {
            get
            {
                var skillDates = from Publication s in Skills
                                 orderby s.Certified descending
                                 select s.Certified;
                return skillDates.First();
            }
        }
        public DateTime EndDate
        {
            get
            {
                var skillDates = from Publication s in Skills
                                 orderby s.Certified ascending
                                 select s.Certified;
                return skillDates.Last();
            }
        }

        public override string ToString()
        {
            //For the purposes of this week's demonstration this returns only the name
            return Name;
        }
    }
}
