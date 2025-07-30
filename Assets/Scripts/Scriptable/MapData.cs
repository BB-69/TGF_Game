using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map Data")]
public class MapData : ScriptableObject
{
    public string mapName;
    public GameObject mapPrefab;

    public int targetHeadCount;
}