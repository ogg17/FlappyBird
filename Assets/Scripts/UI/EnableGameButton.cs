using EventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class EnableGameButton : MonoBehaviour
    {
        void Start()
        {
            var startButton = GetComponent<Button>();
            startButton.onClick.AddListener(EventsInstance.Events.EnableGame.Invoke);
        }
    }
}
