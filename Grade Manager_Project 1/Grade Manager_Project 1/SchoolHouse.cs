using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Manager_Project_2
{
    public class SchoolHouse
    {
        public List<ClassRoom> classRoomList = new List<ClassRoom>();
        public void MainMenu()
        {
            bool systemRunning = true;
            while (systemRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Grade Board");
                Console.WriteLine();
                Console.WriteLine("Enter a selection number.");
                Console.WriteLine();
                Console.WriteLine("1 - List class names");
                Console.WriteLine("2 - Add Classroom");
                Console.WriteLine("3 - Edit A Classroom");
                Console.WriteLine("4 - Delete A Classroom");
                Console.WriteLine("5 - Close Program");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        ListClassRooms();
                        Console.WriteLine("Enter the class number followed by the enter key to select a class.");
                        Int32 classSelection = Int32.Parse(Console.ReadLine());
                        if (classSelection < classRoomList.Count)
                        {
                            ListStudents(classSelection);
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Entry.");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        Console.Clear();
                        AddClassroom();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        ClassRoomSelect();
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Which classroom would you like to delete.");
                        Console.WriteLine("Enter the number of the class you like to delete.");
                        ListClassRooms();
                        classRoomDelete();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid intput. Hit enter to return to Main Menu.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void ListClassRooms()
        {
            int i = 0;
            foreach (var classRoom in classRoomList)
            {
                Console.WriteLine(i + " - " + classRoom.classRoomName);
                i++;
            }
        }
        public void classRoomDelete()
        {
            int classSelection = Int32.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(classRoomList[classSelection].classRoomName + " has been removed.");
            classRoomList.RemoveAt(classSelection);
            Console.ReadLine();
        }

        public void AddClassroom()
        {
            ClassRoom c = new ClassRoom();
            classRoomList.Add(c);
            Console.Write("Please enter the name of the new class: ");
            c.classRoomName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter a description of the new class.");
            c.classDescription = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(c.classRoomName + " added to Class Room List.");
        }
        public void ClassRoomSelect()
        {
            ListClassRooms();
            Console.WriteLine("Select a class to edit.");
            int classSelection = int.Parse(Console.ReadLine());
            Console.Clear();
            ClassRoomMenu(classSelection);
        }
        public void ClassRoomMenu(int classSelection)
        {
            //This is the ClassRoom menu of the program.
            char menuSelect = '0';
            while (menuSelect != '5')
            {
                Console.Clear();
                Console.WriteLine($"Welcome to {classRoomList[classSelection].classRoomName}");
                Console.WriteLine(classRoomList[classSelection].classDescription);
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine();  
                Console.WriteLine("1 - View students in this class");
                Console.WriteLine("2 - Edit the name of the class.");
                Console.WriteLine("3 - Edit the description of the class.");
                Console.WriteLine("4 - Edit students in the class.");
                Console.WriteLine("5 - Go back to Class Class Room Selection Menu.");
                menuSelect = Convert.ToChar(Console.ReadLine());
                //switch statement to navigate to the correct method.
                switch (menuSelect)
                {
                    case '1':
                        ListStudents(classSelection);
                        Console.ReadLine();
                        break;
                    case '2':
                        Console.Clear();
                        Console.Write("Enter new class name: ");
                        classRoomList[classSelection].classRoomName = Console.ReadLine();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter new class description: ");
                        classRoomList[classSelection].classDescription = Console.ReadLine();
                        break;
                    case '4':
                        Console.Clear();
                        StudentEditMenu(classSelection);
                        Console.ReadLine();
                        break;
                    case '5':
                        Console.Clear();
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid intput. Hit enter to return to Classrooms Main Menu.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void ListStudentGrades(int classSelection, int studentSelection)
        {
            int i = 0;
            foreach (var assignment in classRoomList[classSelection].studentList[studentSelection].assignmentList)
            {
                Console.WriteLine(i + classRoomList[classSelection].studentList[studentSelection].assignmentList[i].assignmentName + " - " + classRoomList[classSelection].studentList[studentSelection].assignmentList[i].assignmentGrade + "%");
                i++;
            }
        }
        public double GetGrade(int classSelection, int studentSelection)
        {
            if (classRoomList[classSelection].studentList[studentSelection].assignmentList.Count >= 1)
            {
                int i = 0;
                double runningTotal = 0;
                foreach (var assignment in classRoomList[classSelection].studentList[studentSelection].assignmentList)
                {
                    runningTotal = classRoomList[classSelection].studentList[studentSelection].assignmentList[i].assignmentGrade + runningTotal;
                    i++;
                }
                runningTotal = runningTotal / classRoomList[classSelection].studentList[studentSelection].assignmentList.Count;
                return runningTotal;
            }
            else
                return 0;
        }
        public void ListStudents(int classSelection)
        {
            int i = 0;
            foreach (var student in classRoomList[classSelection].studentList)
            {
                Console.WriteLine($"#{i} - {classRoomList[classSelection].studentList[i].studentName} - {GetGrade(classSelection, i)}%");
                i++;
            }
        }
        public void StudentEditMenu(int classSelection)
        {
            char objectiveSelection = '0';
            while (objectiveSelection != '6')
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - List the students.");
                Console.WriteLine("2 - Compare two students.");
                Console.WriteLine("3 - Add a student.");
                Console.WriteLine("4 - Remove a student.");
                Console.WriteLine("5 - Edit a student/add or remove student grades.");
                Console.WriteLine("6 - Go back to the class room menu.");
                objectiveSelection = char.Parse(Console.ReadLine());
                switch (objectiveSelection)
                {

                    case '1':
                        Console.Clear();
                        ListStudents(classSelection);
                        Console.ReadLine();
                        break;
                    case '2':
                        Student student = new Student();
                        Console.Write("Enter the name of the new student: ");
                        student.studentName = Console.ReadLine();
                        classRoomList[classSelection].studentList.Add(student);
                        Console.WriteLine($"{student.studentName} has been added to the class.");
                        Console.Clear();
                        break;
                    case '3':
                        Console.Clear();
                        ListStudents(classSelection);
                        Console.WriteLine("Enter the students number to remove the student.");
                        int remove = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"Student {classRoomList[classSelection].studentList[remove].studentName} has been removed.");
                        classRoomList[classSelection].studentList.RemoveAt(remove);
                        Console.Clear();
                        break;
                    case '4':
                        Console.Clear();
                        ListStudents(classSelection);
                        Console.Write("Choose the student number you would like to edit: ");
                        int studentSelection = Int32.Parse(Console.ReadLine());
                        studentEditor(classSelection, studentSelection);
                        break;
                    case '5':
                        Console.Clear();
                        ListStudents(classSelection);
                        Console.Write("Choose the student number you would like to compare: ");
                        int studentSelection1 = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                        ListStudents(classSelection);
                        Console.Write("Now, choose a student to compare to: ");
                        int studentSelection2 = Int32.Parse(Console.ReadLine());
                        studentCompare(classSelection, studentSelection1, studentSelection2);
                        break;
                    case '6':
                        break;
                    default:
                        Console.WriteLine("Invalid entry, hit enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void studentCompare(int cS, int s1, int s2)
        {
            double s1Grade = GetGrade(cS, s1);
            double s2Grade = GetGrade(cS, s2);
             
            Console.WriteLine($"{classRoomList[cS].studentList[s1].studentName}'s grade is {s1Grade} %");
            Console.WriteLine($"{classRoomList[cS].studentList[s1].studentName}'s grade is {s2Grade} %");
            if (s1Grade > s2Grade)
            {
                double diff = s1Grade - s2Grade;
                Console.WriteLine($"{classRoomList[cS].studentList[s1].studentName}'s grade is higher than {classRoomList[cS].studentList[s2].studentName}'s grade by a difference of {diff}%.");
            }
            else if (s1Grade < s2Grade)
            {
                double diff = s2Grade - s1Grade;
                Console.WriteLine($"{classRoomList[cS].studentList[s2].studentName}'s grade is higher than {classRoomList[cS].studentList[s1].studentName}'s grade by a difference of {diff}%.");
            }
            else
            {
                Console.WriteLine("Both Grades are equal.");
                Console.ReadLine();
            }
        }
        public void studentEditor(int classSelection, int studentSelectiion)
        {
            int studentMenuSelect = 0;
            while (studentMenuSelect != 5)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Add grade to student.");
                Console.WriteLine("2 - Remove grade from student");
                Console.WriteLine("3 - Edit Student's name.");
                Console.WriteLine("4 - List the students grades.");
                Console.WriteLine("5 - Return to classroom menu.");
                studentMenuSelect = int.Parse(Console.ReadLine());
                switch (studentMenuSelect)
                {
                    //              classRoomList[classSelection].studentList[studentSelectiion].assignmentList
                    case 1:
                        Console.Clear();
                        Assignment assignment = new Assignment();
                        Console.Write("Enter the name of the assignment: ");
                        assignment.assignmentName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Enter the grade the student earned of the assignment.");
                        Console.WriteLine("Enter a zero if the assignment is incomplete or a 0%");
                        assignment.assignmentGrade = Double.Parse(Console.ReadLine());
                        classRoomList[classSelection].studentList[studentSelectiion].assignmentList.Add(assignment);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        ListStudentGrades(classSelection, studentSelectiion);
                        Console.WriteLine("Choose the number of the grade to be removed.");
                        classRoomList[classSelection].studentList[studentSelectiion].assignmentList.RemoveAt(Int32.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the new name of the student: ");
                        classRoomList[classSelection].studentList[studentSelectiion].studentName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Name changed.");
                        break;
                    case 4:
                        Console.Clear();
                        int i = 1;
                        Console.WriteLine(classRoomList[classSelection].studentList[studentSelectiion].studentName + "'s total grade is " + GetGrade(classSelection, studentSelectiion) + '%');
                        foreach (var gradedAssignments in classRoomList[classSelection].studentList[studentSelectiion].assignmentList)
                        {
                            Console.WriteLine($"#{i} - {gradedAssignments.assignmentName} -  {gradedAssignments.assignmentGrade}%");
                        }
                        Console.ReadLine();
                        break;
                    case 5:

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
    }
}
    
