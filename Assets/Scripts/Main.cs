using System;
using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using EventSystem;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private ConversionDataScript conversionDataScript;
    [SerializeField] private TMProLabelScript conversionDataLabel;

    private GameData _gameData;
    void Start()
    {
        ConversionDataStartConfiguration();
    }

    void ConversionDataStartConfiguration()
    {
        _gameData = Resources.Load(nameof(GameData)) as GameData;
        conversionDataScript.SetGameDataObj(_gameData);
        AppsFlyer.getConversionData(conversionDataScript.name);
        EventsInstance.Events.GetConversionData += () => conversionDataLabel.SetText(_gameData.conversionData);
    }

    // Update is called once per frame
    void Update()
    {
       // if (_gameData.conversionData != string.Empty) conversionDataLabel.SetText(_gameData.conversionData);
    }
}
