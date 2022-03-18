using DataAccess;
using System;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    public interface IAddViewModel
    {
        DateTime _SelectedDate { get; set; }
        string NameWorkout { get; set; }
        IDBProcessor Processor { get; }

        event EventHandler<string> _addEvent;

        void AddWorkout();
    }
}