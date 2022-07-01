using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Manager_Project_2
{
    public class Student
    {
        public string studentName { get; set; }
        public List<Assignment> assignmentList = new List<Assignment>();
    }
}
