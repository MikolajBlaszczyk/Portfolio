using Caliburn.Micro;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    class DateViewModel : Screen, IDateViewModel
    {
        public event EventHandler<DateTime> datePickedEvent;

        private DateTime selectedDate = Date.Now;

        public string DateText
        {
            get { return SelectedDate.ToShortDateString(); }
        }
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; NotifyOfPropertyChange(() => SelectedDate); NotifyOfPropertyChange(() => DateText); }
        }

        public void ConfirmBtn()
        {
            datePickedEvent?.Invoke(this, SelectedDate);
        }

    }
}
