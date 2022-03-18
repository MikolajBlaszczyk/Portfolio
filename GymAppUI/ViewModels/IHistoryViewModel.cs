using Caliburn.Micro;
using DataAccess;
using GymAppUI.Models;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    public interface IHistoryViewModel
    {
        IDBProcessor Processor { get; }
        WorkoutModelUIWithID SelectedWorkout { get; set; }
        BindableCollection<WorkoutModelUIWithID> Workouts { get; set; }

        void Delete();
        Task OnInitilize();
    }
}