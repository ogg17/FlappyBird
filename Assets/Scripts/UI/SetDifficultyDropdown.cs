using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class SetDifficultyDropdown : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;
        void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            var data = Resources.Load(nameof(GameData)) as GameData;
            _dropdown.value = (int)data!.difficulty;
        }

    }
}
