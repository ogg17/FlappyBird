using System.Collections.Generic;
using System.Text;
using AppsFlyerSDK;
using EventSystem;
using UnityEngine;

public class ConversionDataScript : MonoBehaviour, IAppsFlyerConversionData
{
    private GameData _gameData;
    
    public string devKey;
    private readonly string _appID = null;
    public string UWPAppID;
    public string macOSAppID;
    public bool isDebug;
    public bool getConversionData;
    
    void Start()
    {
        AppsFlyer.setIsDebug(isDebug);
#if UNITY_WSA_10_0 && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, UWPAppID, getConversionData ? this : null);
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, macOSAppID, getConversionData ? this : null);
#else
        AppsFlyer.initSDK(devKey, _appID, getConversionData ? this : null);
#endif

        AppsFlyer.startSDK();
    }
    
    public void SetGameDataObj(GameData data)
    {
        _gameData = data;
    }

    void Update()
    {
    }
    
    public void onConversionDataSuccess(string conversionData)
    {
        print(conversionData);
        AppsFlyer.AFLog("didReceiveConversionData", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        _gameData.conversionData = ConversionDataDictToStr(conversionDataDictionary);
        EventsInstance.Events.GetConversionData.Invoke();
    }

    private string ConversionDataDictToStr(Dictionary<string, object> data)
    {
        var str = new StringBuilder();
        foreach (var item in data)
            str.Append(item.Key).Append(": ").Append(item.Value).AppendLine();
        
        return str.ToString();
    }

    public void onConversionDataFail(string error)
    {
        AppsFlyer.AFLog("didReceiveConversionDataWithError", error);
    }

    public void onAppOpenAttribution(string attributionData)
    {
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        // add direct deeplink logic here
    }

    public void onAppOpenAttributionFailure(string error)
    {
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }
}