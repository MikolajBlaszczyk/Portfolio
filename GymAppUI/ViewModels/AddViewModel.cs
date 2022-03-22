using Serilog;
using Caliburn.Micro;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    public class AddViewModel : Screen, IAddViewModel
    {
        public IDBProcessor Processor { get; }

        public event EventHandler<string> _addEvent;
        public event EventHandler _datePicker;
        public event EventHandler _closeCalendarEvent;

        private string _nameWorkout;
        private DateTime _date = DateTime.Now;

        public string Date 
        {
            get{ return _SelectedDate.ToShortDateString(); }
        }
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

        private void DatePicker_datePickedEvent(object sender, DateTime e)
        {
            _SelectedDate = e;
            _closeCalendarEvent?.Invoke(this, EventArgs.Empty);
        }
        public void AddWorkout()
        {
            try
            {
                if (NameWorkout is not null)
                {
                    Processor.InsertWorkout(_SelectedDate, NameWorkout);
                    _addEvent?.Invoke(this, NameWorkout);
                    Log.Logger.Information("Success");
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error(e,"Workout wasn't added, exceptions occurred");
            }
        }
        public void Calendar()
        {
            _datePicker?.Invoke(this,EventArgs.Empty);
        }
        
    }
}
