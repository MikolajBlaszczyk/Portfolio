using Caliburn.Micro;
using GymAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace GymAppUI.Helper
{
    public class ListConverter : IListConverter
    {


        public BindableCollection<WorkoutUIModel> ConvertListW(List<WorkoutModel> workouts)
        {
            BindableCollection<WorkoutUIModel> output = new BindableCollection<WorkoutUIModel>();

            foreach (WorkoutModel workout in workouts)
            {
                output.Add(new WorkoutUIModel() { Name = workout.WorkoutName, Date = workout.WorkoutDate.ToString("dd/mm/yyyy") });
            }

            return output;
        }

        public BindableCollection<ExcerciseUIModel> ConvertListE(List<ExcerciseNameModel> names)
        {
            BindableCollection<ExcerciseUIModel> output = new BindableCollection<ExcerciseUIModel>();

            foreach (ExcerciseNameModel name in names)
            {
                output.Add(new ExcerciseUIModel { Name = name.ExcersiseName });
            }

            return output;
        }

        public BindableCollection<WorkoutModelUIWithID> ConvertListWID(List<WorkoutModel> input)
        {
            BindableCollection<WorkoutModelUIWithID> output = new BindableCollection<WorkoutModelUIWithID>();

            foreach (var item in input)
            {
                output.Add(new WorkoutModelUIWithID() { ID = item.WorkoutID, Name = item.WorkoutName, Date = item.WorkoutDate.ToString("dd/mm/yyyy") });
            }

            return output;
        }
    }
}
