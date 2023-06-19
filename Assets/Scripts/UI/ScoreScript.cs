using EventSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreScript : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            EventsInstance.Events.ScoreChange += OnChangeScore;
        }

        private void OnChangeScore(int s) => _text.text = s.ToString();
    }
}