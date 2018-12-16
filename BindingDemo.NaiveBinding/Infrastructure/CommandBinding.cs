using System;
using System.Reflection;
using System.Windows.Input;

namespace BindingDemo.NaiveBinding.Infrastructure
{
    class CommandBinding<TTarget> : Binding
    {
        private readonly ICommand _command;
        private readonly TTarget _targetObject;
        private readonly EventInfo _eventInfo;

        private readonly EventHandler _handler;

        public CommandBinding(
            ICommand command,
            TTarget targetObject,
            string eventName)
        {
            _command = command;
            _targetObject = targetObject;
            _eventInfo = GetEvent(targetObject.GetType(), eventName);
            _handler = new EventHandler(Handler);

            AddHandlerToEvent();
        }
        
        public override void Dispose()
        {
            _eventInfo.RemoveEventHandler(
                _targetObject,
                _handler);
        }

        private void AddHandlerToEvent()
        {
            _eventInfo.AddEventHandler(
                _targetObject,
                _handler);
        }

        private void Handler(object sender, EventArgs ea)
        {
            if (_command.CanExecute(null))
            {
                _command.Execute(null);
            }
        }

        private EventInfo GetEvent(Type targetObjectType, string eventName)
        {
            return targetObjectType.GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
