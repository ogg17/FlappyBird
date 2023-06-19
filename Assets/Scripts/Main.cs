using System;
using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using EventSystem;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private ConversionDataScript conversionDataScript;
    [SerializeField] private TMProLabelScript conversionDataLabel;

    private GameData _gameData;
    void Start()
    {
        GameDataLoad();
        ConversionDataStartConfiguration();
        EventsInstance.Events.EnableGame += () => { Debug.Log("ENABLE"); };
    }

    void GameDataLoad()
    {
        _gameData = Resources.Load(nameof(GameData)) as GameData;
        if (_gameData != null) _gameData.Load();
    }
    
    void ConversionDataStartConfiguration()
    {
        conversionDataScript.SetGameDataObj(_gameData);
        EventsInstance.Events.GetConversionData += () => conversionDataLabel.SetText(_gameData.conversionData);
    }
    
    private void OnApplicationQuit()
    {
        _gameData.Save();
    }
}
