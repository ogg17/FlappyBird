using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class SetDifficultyDropdown : MonoBehaviour
    {
        [SerializeField] private GameData gameData;

        private TMP_Dropdown _dropdown;

        private void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.value = gameData!.difficulty;
        }
    }
}