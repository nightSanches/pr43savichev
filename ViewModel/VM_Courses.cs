using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static pr43savichev.Classes.RelayCommand;
using System.Text.RegularExpressions;
using pr43savichev.Classes;
using pr43savichev.Context;
using pr43savichev.Models;

namespace pr43savichev.ViewModel
{
    public class VM_Courses : Notification
    {
        public CoursesContext coursesContext = new CoursesContext();

        public ObservableCollection<Courses> Courses { get; set; }

        public VM_Courses() => Courses = new ObservableCollection<Courses>();

        public RealyCommand OnAddCourses
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Courses NewCourses = new Courses();
                    Courses.Add(NewCourses);
                    coursesContext.Courses.Add(NewCourses);
                    coursesContext.SaveChanges();
                });
            }
        }
    }
}
