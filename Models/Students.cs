using pr43savichev.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static pr43savichev.Classes.RealyCommand;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace pr43savichev.Models
{
    public class Students : Notification
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string educationYear;

        public string EducationYear
        {
            get { return educationYear; }
            set
            {
                educationYear = value;
                OnPropertyChanged("EducationYear");
            }
        }

        private string group;

        public string Group
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
        }

        private int courseId;
        public int CourseId
        {
            get { return courseId; }
            set
            {
                courseId = value;
                OnPropertyChanged("CourseId");
            }
        }

        [Schema.NotMapped]
        private bool isEnable;

        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }

        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }

        [Schema.NotMapped]
        public RealyCommand OnEdit
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModel.VM_Pages).students.studentsContext.SaveChanges();
                });
            }
        }

        [Schema.NotMapped]
        public RealyCommand OnDelete
        {
            get
            {
                return new RealyCommand(obj =>
                {
                        (MainWindow.init.DataContext as ViewModel.VM_Pages).students.Students.Remove(this);
                        (MainWindow.init.DataContext as ViewModel.VM_Pages).students.studentsContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModel.VM_Pages).students.studentsContext.SaveChanges();
                });
            }
        }

        [Schema.NotMapped]
        public ObservableCollection<Courses> Courses
        {
            get
            {
                return new ObservableCollection<Courses>(new Context.CoursesContext().Courses);
            }
        }
    }
}
