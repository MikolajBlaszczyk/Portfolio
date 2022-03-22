using System;

namespace GymAppUI.ViewModels
{
    public interface IDateViewModel
    {
        string DateText { get; }
        DateTime SelectedDate { get; set; }

        event EventHandler<DateTime> datePickedEvent;

        void ConfirmBtn();
    }
}