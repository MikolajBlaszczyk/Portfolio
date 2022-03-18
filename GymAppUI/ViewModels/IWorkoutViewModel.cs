using Caliburn.Micro;
using DataAccess;
using GymAppUI.Models;
using System;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    public interface IWorkoutViewModel
    {
        BindableCollection<ExcerciseUIModel> Excercise { get; set; }
        IDBProcessor Processor { get; }
        ExcerciseTrainingModel Selected { get; set; }
        ExcerciseUIModel SelectedItem { get; set; }
        BindableCollection<ExcerciseTrainingModel> CurrentTraining { get; set; }

        event EventHandler<WorkoutViewModel> _endOfWorkout;

        void Add();
        Task Delete();
        void Finish();
        Task OnInitilize();
    }
}