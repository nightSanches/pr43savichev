using pr43savichev.Classes;
using pr43savichev.Context;
using pr43savichev.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static pr43savichev.Classes.RelayCommand;

namespace pr43savichev.ViewModel
{
    public class VM_Students : Notification
    {
        public StudentsContext studentsContext = new StudentsContext();

        public ObservableCollection<Students> Students { get; set; }

        public VM_Students() => Students = new ObservableCollection<Students>();

        public RealyCommand OnAddCourses
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Students NewStudents = new Students();
                    Students.Add(NewStudents);
                    studentsContext.Students.Add(NewStudents);
                    studentsContext.SaveChanges();
                });
            }
        }
    }
}
