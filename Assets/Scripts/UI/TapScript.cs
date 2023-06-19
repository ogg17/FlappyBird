using System;
using EventSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapScript : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private float tapDelay;
        
        private DateTime _lastTime = DateTime.Now;
        public void OnPointerClick(PointerEventData eventData)
        {
            var milliseconds = DateTime.Now - _lastTime;
            if (!(milliseconds.TotalMilliseconds > tapDelay)) return;
            _lastTime = DateTime.Now;
            EventsInstance.Events.OnTap.Invoke();
        }
    }
}
