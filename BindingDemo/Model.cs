using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using BindingDemo.BareBinding.Infrastructure;

namespace BindingDemo.BareBinding
{
    public class Model : INotifyPropertyChanged
    {
        private readonly Timer _timer;

        private int _percentage;
        private DateTime _time = DateTime.Now;

        public Command Command { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Percentage
        {
            get => _percentage;
            set
            {
                if (value != _percentage)
                {
                    _percentage = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                if (value != _time)
                {
                    _time = value;
                    OnPropertyChanged();
                }
            }
        }

        public Model()
        {
            _timer = new Timer(Cycle, null, dueTime: 0, period: 10);
            Command = new Command();
        }

        protected void OnPropertyChanged([CallerMemberName]string callerName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        private void Cycle(object state)
        {
            Percentage = DateTime.Now.Millisecond / 100;
            if (Percentage >= 9)
            {
                Time = DateTime.Now;
                Percentage = 0;
            }
        }
    }
}
