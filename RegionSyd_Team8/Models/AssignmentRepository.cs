using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd_Team8.Models
{
    public class AssignmentRepository
    {
        public ObservableCollection<Assignment> Assignments { get; set; }

        public AssignmentRepository()
        {
            Assignments = new ObservableCollection<Assignment>();
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void RemoveAssignment(Assignment assignment)
        {
        }

        public void UpdateAssignment(Assignment assignment)
        {
            //implementation
        }
    }
}
