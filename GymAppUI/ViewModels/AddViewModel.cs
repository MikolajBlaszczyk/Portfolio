using BuisnessLogic;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    class AddViewModel:Screen
    {
        public event EventHandler _addEvent;
        private string  _nameWorkout;
        private DateTime _date = DateTime.Now;

        public DateTime _SelectedDate
        {
            get { return _date; }
            set { _date = value;NotifyOfPropertyChange(() => _SelectedDate); }
        }
        public string  NameWorkout
        {
            get { return _nameWorkout; }
            set { _nameWorkout = value; NotifyOfPropertyChange(() => NameWorkout); }
        }

        public AddViewModel(EventHandler addEvent)
        {
            _addEvent = addEvent;
        } 
        public void AddWorkout()
        {
            DataFlowToDB input = new DataFlowToDB();
            input.TransferingWorkout(_SelectedDate, NameWorkout);
            _addEvent?.Invoke(this, null);
        }
    }
}
