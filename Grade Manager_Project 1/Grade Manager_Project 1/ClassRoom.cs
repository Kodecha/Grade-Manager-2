using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Manager_Project_2
{
    public class ClassRoom
    {
        public string classRoomName { get; set; }
        public string classDescription { get; set; }
        public List<Student> studentList = new List<Student>();
    }
}
