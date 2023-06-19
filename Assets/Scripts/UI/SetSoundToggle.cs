using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Toggle))]
    public class SetSoundToggle : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        
        private Toggle _toggle;

        private void Start()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.isOn = gameData!.isSound;
        }
    }
}
