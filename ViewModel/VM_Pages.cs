using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pr43savichev.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using static pr43savichev.Classes.RealyCommand;

namespace pr43savichev.ViewModel
{
    public class VM_Pages : Notification
    {
        public VM_Courses courses = new VM_Courses();

        public VM_Students students = new VM_Students();

        public VM_Pages() => 
            MainWindow.init.frame.Navigate(new View.Students.Main(students));

        public RealyCommand OpenStudents
        {
            get => new RealyCommand(obj => MainWindow.init.frame.Navigate(new View.Students.Main(students)));
        }

        public RealyCommand OpenCourses
        {
            get => new RealyCommand(obj => MainWindow.init.frame.Navigate(new View.Courses.Main(courses)));
        }
    }
}
