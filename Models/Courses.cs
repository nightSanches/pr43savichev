using pr43savichev.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static pr43savichev.Classes.RelayCommand;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace pr43savichev.Models
{
    public class Courses : Notification
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

        private string otdelenye;

        public string Otdelenye
        {
            get { return otdelenye; }
            set
            {
                otdelenye = value;
                OnPropertyChanged("Otdelenye");
            }
        }

        private string budgetMest;

        public string BudgetMest
        {
            get { return budgetMest; }
            set
            {
                budgetMest = value;
                OnPropertyChanged("BudgetMest");
            }
        }

        private string plantyhMest;

        public string PlantyhMest
        {
            get { return plantyhMest; }
            set
            {
                plantyhMest = value;
                OnPropertyChanged("PlantyhMest");
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
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModel.VM_Pages).courses.coursesContext.SaveChanges();
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
                    (MainWindow.init.DataContext as ViewModel.VM_Pages).courses.Courses.Remove(this);
                    (MainWindow.init.DataContext as ViewModel.VM_Pages).courses.coursesContext.Remove(this);
                    (MainWindow.init.DataContext as ViewModel.VM_Pages).courses.coursesContext.SaveChanges();
                });
            }
        }
    }
}
