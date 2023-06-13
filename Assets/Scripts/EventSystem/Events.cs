using System;
using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(menuName = "SO/" + nameof(Events), fileName = nameof(Events))]
    public class Events: ScriptableObject
    {
        public Action TestEvent;
        public Action OnTap;
    }
}
