using System.ComponentModel;

namespace StateManagement.States
{
    public class StateContainer 
    {
        private int _counter;

        public int Counter {
            get => _counter;
            set
            {
                _counter = value;
                OnNotification();
            }
        }

        public Action? Notification;

        private void OnNotification()
        {
            Notification?.Invoke();
        }
    }
}
