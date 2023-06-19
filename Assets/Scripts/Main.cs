// Author: Gavrilov Vsevolod
// Email: vsevolod.gavrilov.17@gmail.com
// Completion Time: 18 hours

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
        if (gameData != null) gameData.Load();
        ConversionDataStartConfiguration();
        SetGameStates();
        Application.targetFrameRate = 60;
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
        EventsInstance.Events.EnableGame += OnEnableGame;
    }

    private void OnEnableGame()
    {
        gameData.isGame = false;
        gameData.Score = 0;
    }

    private void OnStartGame() => gameData.isGame = true;

    private void OnGameOver()
    {
        gameData.isGame = false;
        gameData.Score = 0;
    }

    private void OnApplicationPause(bool pauseStatus) => gameData.Save();

    private void OnApplicationQuit() => gameData.Save();
}