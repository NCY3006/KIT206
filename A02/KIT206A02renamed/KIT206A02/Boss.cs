using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Research;
using RAP.Database;
using RAP.Control;
using RAP;

namespace RAP
{
    class Boss
    {

        private List<Researcher> staff;
        public List<Researcher> Workers { get { return staff; } set { } }

        private ObservableCollection<Researcher> viewableStaff;
        public ObservableCollection<Researcher> VisibleWorkers { get { return viewableStaff; } set { } }

        public Boss()
        {
            staff = ERDAdapter.FetchBasicResearcher();
            viewableStaff = new ObservableCollection<Researcher>(staff); //this list we will modify later

            //Part of step 2.3.2 from Week 8 tutorial
            foreach (Researcher e in staff)
            {
                e.Work = ERDAdapter.FetchBasicPublication(e.ID);
            }
        }

        public ObservableCollection<Researcher> GetViewableList()
        {
            return VisibleWorkers;
        }

        //This version of Filter modifies the viewable list instead of returning a new list,
        //but the procedure is almost the same
        //public void Filter(Researcher type)
        //{
        //    var selected = from Researcher e in staff
        //                   where type == Placement.Any || e.Type == type
        //                   select e;
        //    viewableStaff.Clear();
        //    //Converts the result of the LINQ expression to a List and then calls viewableStaff.Add with each element of that list in turn
        //    selected.ToList().ForEach(viewableStaff.Add);
        //}

    }
}
