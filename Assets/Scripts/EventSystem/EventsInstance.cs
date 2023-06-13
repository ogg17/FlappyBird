using UnityEngine;

namespace EventSystem
{
    public static class EventsInstance
    {
        private static Events _events;

        public static Events Events
        {
            get
            {
                if (_events == null) _events = Resources.Load(nameof(Events)) as Events;
                return _events;
            }
            private set => _events = value;
        }
    }
}