using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMProLabelScript : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        private void Start() => _textMesh = GetComponent<TextMeshProUGUI>();

        public void SetText(string text) => _textMesh.SetText(text);
    }
}