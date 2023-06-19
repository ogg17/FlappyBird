using System;
using UnityEngine;

namespace EventSystem
{
    public class Events
    {
        public Action TestEvent = () => { };
        public Action OnTap = () => { };
        public Action EnableGame = () => { };
        public Action StartGame = () => { };
        public Action ChangeLevel = () => { };
        public Action GameOver = () => { };
        public Action GetConversionData = () => { };
        public Action SoundChange = () => { };
        public Action DifficultyChange = () => { };
        public Action<int> ScoreChange = s => { };
    }
}