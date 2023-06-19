using EventSystem;
using UnityEngine;

[CreateAssetMenu(menuName = GameConstants.ScrObjDirectory + nameof(GameData), fileName = nameof(GameData))]
public class GameData : ScriptableObject
{
    public string conversionData;
    public bool isSound;
    public int difficulty;
    public bool isGame = false;
    public int record;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            EventsInstance.Events.ScoreChange.Invoke(_score);
        }
    }
    
    private int _score;

    public void SetSound(bool value)
    {
        isSound = value;
        EventsInstance.Events.SoundChange.Invoke();
        PlayerPrefs.SetInt(nameof(isSound), isSound ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetDifficulty(int value)
    {
        difficulty = value;
        EventsInstance.Events.DifficultyChange.Invoke();
        PlayerPrefs.SetInt(nameof(difficulty), difficulty);
        PlayerPrefs.Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt(nameof(record), record);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        isSound = PlayerPrefs.GetInt(nameof(isSound)) != 0;
        difficulty = PlayerPrefs.GetInt(nameof(difficulty));
        record = PlayerPrefs.GetInt(nameof(record));
    }
}