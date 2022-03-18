using Caliburn.Micro;
using DataAccess;
using GymAppUI.Models;
using System.Collections.Generic;

namespace GymAppUI.Helper
{
    public interface IListConverter
    {
        BindableCollection<ExcerciseUIModel> ConvertListE(List<ExcerciseNameModel> names);
        BindableCollection<WorkoutUIModel> ConvertListW(List<WorkoutModel> workouts);
        BindableCollection<WorkoutModelUIWithID> ConvertListWID(List<WorkoutModel> input);
    }
}