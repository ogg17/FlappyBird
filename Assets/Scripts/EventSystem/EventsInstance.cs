using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public static class EventsInstance
    {
        private static Events _events;
        public static Events Events
        {
            get => _events ??= Resources.Load(nameof(Events)) as Events;
            private set => _events = value;
        }
    }
}