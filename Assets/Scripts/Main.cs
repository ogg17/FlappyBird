using EventSystem;
using UI;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private ConversionDataScript conversionDataScript;
    [SerializeField] private TMProLabelScript conversionDataLabel;

    [SerializeField] private GameData gameData;

    private void Start()
    {
        GameDataLoad();
        ConversionDataStartConfiguration();
        SetGameStates();
    }

    private void GameDataLoad()
    {
        if (gameData != null) gameData.Load();
        gameData.isGame = false;
        gameData.Score = 0;
    }

    private void ConversionDataStartConfiguration()
    {
        conversionDataScript.SetGameDataObj(gameData);
        EventsInstance.Events.GetConversionData += () => conversionDataLabel.SetText(gameData.conversionData);
    }

    private void SetGameStates()
    {
        EventsInstance.Events.StartGame += OnStartGame;
        EventsInstance.Events.GameOver += OnGameOver;
    }
    
    private void OnStartGame() => gameData.isGame = true;
    private void OnGameOver()
    {
        gameData.isGame = false;
        gameData.Score = 0;
    }

    private void OnApplicationQuit()
    {
        gameData.Save();
    }
}
