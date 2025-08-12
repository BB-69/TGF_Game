#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "PathfindingData", menuName = "Pathfinding/Map Data")]
public class PathfindingData : ScriptableObject
{
    public int width = 20;
    public int height = 20;
    public Vector2Int offset = Vector2Int.zero;
    public float cellSize = 1f;

    public bool[] walkableMap { get; private set; }

    public bool GetWalkable(int x, int y)
    {
        int index = y * width + x;
        return index < walkableMap.Length ? walkableMap[index] : true;
    }

    public void SetWalkable(int x, int y, bool walkable)
    {
        walkableMap[y * width + x] = walkable;
    }

    public void Init()
    {
        bool[] prevData = walkableMap;
        walkableMap = new bool[width * height];
        int size = Mathf.Min((prevData ?? walkableMap).Length, walkableMap.Length);
        for (int i = 0; i < size; i++)
            walkableMap[i] = prevData?[i] ?? true;
    }
}
