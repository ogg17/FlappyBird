using EventSystem;
using UnityEngine;

[CreateAssetMenu(menuName = GameConstants.ScrObjDirectory + nameof(GameData), fileName = nameof(GameData))]
public class GameData : ScriptableObject
{
    public string conversionData;
    private bool _isSound;

    public bool isSound;

    public DifficultyTypes difficulty;

    public void SetSound(bool value)
    {
        isSound = value;
        EventsInstance.Events.SoundChange.Invoke();
    }
    public void SetDifficulty(int value)
    {
        difficulty = (DifficultyTypes)value;
        EventsInstance.Events.DifficultyChange.Invoke();
    }

    public void Save()
    {
        PlayerPrefs.SetInt(nameof(_isSound), _isSound ? 1 : 0);
        PlayerPrefs.SetInt(nameof(difficulty), (int)difficulty);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        _isSound = PlayerPrefs.GetInt(nameof(_isSound)) != 0;
        difficulty = (DifficultyTypes)PlayerPrefs.GetInt(nameof(difficulty));
    }
}