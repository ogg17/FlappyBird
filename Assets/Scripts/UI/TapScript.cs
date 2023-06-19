using EventSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapScript : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private float tapDelay;

        private float _lastTime;

        public void OnPointerClick(PointerEventData eventData)
        {
            var milliseconds = Time.time * 1000 - _lastTime;
            if (!(milliseconds > tapDelay)) return;
            _lastTime = Time.time * 1000;
            EventsInstance.Events.OnTap.Invoke();
        }
    }
}