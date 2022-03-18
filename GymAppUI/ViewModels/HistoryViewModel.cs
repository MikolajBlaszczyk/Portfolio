
using Caliburn.Micro;
using GymAppUI.Models;
using GymAppUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccess;

namespace GymAppUI.ViewModels
{
    public class HistoryViewModel : Screen, IHistoryViewModel
    {
        public IDBProcessor Processor { get; }
        public IListConverter ListConverter { get; }
        public IConvertExcercise CollectionConverter { get; }

        private BindableCollection<WorkoutModelUIWithID> workouts;
        private WorkoutModelUIWithID _selectedWorkout;

        public WorkoutModelUIWithID SelectedWorkout
        {
            get { return _selectedWorkout; }
            set { _selectedWorkout = value; NotifyOfPropertyChange(() => SelectedWorkout); }
        }
        public BindableCollection<WorkoutModelUIWithID> Workouts
        {
            get { return workouts; }
            set { workouts = value; NotifyOfPropertyChange(() => Workouts); }
        }



        public HistoryViewModel(IDBProcessor processor, IListConverter listConverter, IConvertExcercise collectionConverter)
        {
            Processor = processor;
            ListConverter = listConverter;
            CollectionConverter = collectionConverter;
        }

        public async Task OnInitilize()
        {
            Workouts = ListConverter.ConvertListWID(await Processor.GetWorkout());
        }

        public void Delete()
        {

            Processor.DeleteWorkout(SelectedWorkout.ID);
            Workouts.Remove(SelectedWorkout);
        }

    }
}
