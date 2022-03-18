using System;

namespace GymAppUI.ViewModels
{
    public interface IShellViewModel
    {
        bool CanAddbtn { get; set; }
        bool CanWorkoutbtn { get; set; }

        

        void Addbtn();
        void Historybtn();
        void Homebtn();
        void Workoutbtn();
    }
}