using BuisnessLogic;
using Caliburn.Micro;
using GymAppUI.Models;
using GymAppUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GymAppUI.ViewModels
{
    class HistoryViewModel:Screen
    {
        private BindableCollection<WorkoutModelUIWithID> workouts;
        private WorkoutModelUIWithID _selectedWorkout;

        public WorkoutModelUIWithID SelectedWorkout
        {
            get { return _selectedWorkout; }
            set { _selectedWorkout = value;NotifyOfPropertyChange(() => SelectedWorkout); }
        }
        public BindableCollection<WorkoutModelUIWithID> Workouts
        {
            get { return workouts; }
            set { workouts = value; NotifyOfPropertyChange(() => Workouts); }
        }

        public HistoryViewModel()
        {
            DataFlowFromDB pull = new DataFlowFromDB();
            ListConverter convert = new ListConverter();

            Workouts = convert.ConvertListWID(pull.PullWorkoutsID());
            
        }

        public void Delete()
        {      
            DataFlowToDB delete = new DataFlowToDB();
          
            delete.DeletingWorkout(SelectedWorkout.ID);
            Workouts.Remove(SelectedWorkout);
        }
        
    }
}
