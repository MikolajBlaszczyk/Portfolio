using DataAccess;
using System;

namespace GymAppUI.ViewModels
{
    public interface IAddViewModel
    {
        DateTime _SelectedDate { get; set; }
        string NameWorkout { get; set; }
        IDBProcessor Processor { get; }

        event EventHandler _addEvent;

        void AddWorkout();
    }
}