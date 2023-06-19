using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = GameConstants.ScrObjDirectory + nameof(GameData), fileName = nameof(GameData))]
public class GameData : ScriptableObject
{
    public string conversionData;
}
