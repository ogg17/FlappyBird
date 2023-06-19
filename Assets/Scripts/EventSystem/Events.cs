using System;
using UnityEngine;

namespace EventSystem
{
    public class Events
    {
        public Action TestEvent = () => {};
        public Action OnTap = () => {};
        public Action GetConversionData = () => {};
        public Action SoundChange = () => {};
        public Action DifficultyChange = () => {};
    }
}
