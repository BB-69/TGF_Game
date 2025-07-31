using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map Data")]
public class MapData : ScriptableObject
{
    public string mapName;
    public string sceneName;

    public int targetHeadCount;
}