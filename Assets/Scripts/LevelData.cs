using UnityEngine;

[CreateAssetMenu(menuName = GameConstants.ScrObjDirectory + nameof(LevelData), fileName = nameof(LevelData))]
public class LevelData : ScriptableObject
{
    public int duration;
    public float speed;
    public float tubeSpace;
}
