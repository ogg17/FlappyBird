using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Toggle))]
    public class SetSoundToggle : MonoBehaviour
    {
        private Toggle _toggle;
        void Start()
        {
            _toggle = GetComponent<Toggle>();
            var data = Resources.Load(nameof(GameData)) as GameData;
            _toggle.isOn = data!.isSound;
        }
    }
}
