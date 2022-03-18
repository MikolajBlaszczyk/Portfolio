
using Caliburn.Micro;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    public class AddViewModel : Screen, IAddViewModel
    {
        public IDBProcessor Processor { get; }

        public event EventHandler _addEvent;
        private string _nameWorkout;
        private DateTime _date = DateTime.Now;

        public DateTime _SelectedDate
        {
            get { return _date; }
            set { _date = value; NotifyOfPropertyChange(() => _SelectedDate); }
        }
        public string NameWorkout
        {
            get { return _nameWorkout; }
            set { _nameWorkout = value; NotifyOfPropertyChange(() => NameWorkout); }
        }



        public AddViewModel(IDBProcessor processor)
        {
            Processor = processor;
        }
        public void AddWorkout()
        {
            Processor.InsertWorkout(_SelectedDate, NameWorkout);
            _addEvent?.Invoke(this, null);
        }
    }
}
