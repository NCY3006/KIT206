using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace KIT206_Week10_Sample
{
  
        public enum Campus { Hobart, Launceston, [Description("Cradle Coast")] CradleCoast };

        public abstract class Researcher
        {
 
            public int Id { get; set; }
            public string Title { get; set; }
            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public EmploymentLevel CurrentJob { get; set; }

       
            public Campus Campus { get; set; }
            public string School { get; set; }
            public string Email { get; set; }
            public DateTime CurrentJobStart { get; set; }
            public DateTime EarliestStart { get; set; }
      
        }
}
