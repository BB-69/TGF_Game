using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathManager : MonoBehaviour
{
    Logger log;
    public PathfindingData data;

    [Header("Data")]
    public int width = 20;
    public int height = 20;
    public Vector2Int offset = Vector2Int.zero;
    public float cellSize = 1f; // FIX: changing size does not dynamically resize the entire grid, only cell size itself
    private Dictionary<GameObject, PathNode> entityNodes = new Dictionary<GameObject, PathNode>();
    public static PathManager Instance { get; private set; }
    public PathFinding pathFinding;

    private void Awake()
    {
        if (Instance != null) { Destroy(this.gameObject); }
        else Instance = this;
    }

    private void OnEnable()
    {
        log = new Logger("PathFinding", null);

        if (data != null) LoadFromData();
        else
        {
            pathFinding = new PathFinding(width, height, offset);
            log.Warn("No PathFinding Data Assigned!");
        }
    }

    private void OnDisable()
    {
        if (data != null) SaveToData();
    }

    private void Update()
    {
        foreach (var entityNode in entityNodes)
        {
            GameObject entity = entityNode.Key;
            UpdateEntityPosition(entity);
        }
    }

    public void RegisterEntity(GameObject entity)
    {
        if (!entityNodes.ContainsKey(entity))
        {
            PathNode node = GetNodeFromWorldPos(entity.transform.position);
            entityNodes[entity] = node;
            node.occupant = entity;
        }
    }

    public void UnregisterEntity(GameObject entity)
    {
        if (entityNodes.TryGetValue(entity, out PathNode node))
        {
            node.occupant = null;
            entityNodes.Remove(entity);
        }
    }

    //call to update each entity current node
    private void UpdateEntityPosition(GameObject entity)
    {
        PathNode oldNode = entityNodes[entity];
        PathNode newNode = GetNodeFromWorldPos(entity.transform.position);

        if (newNode != oldNode)
        {
            if (oldNode != null) oldNode.occupant = null;
            newNode.occupant = entity;
            entityNodes[entity] = newNode;
        }
    }

    public PathNode GetEntityPosition(GameObject entity) => entityNodes[entity];

    public PathNode GetNodeFromWorldPos(Vector3 worldPos)
    {
        var grid = pathFinding.GetGrid();
        grid.GetXYFromWorldPosition(worldPos, out int x, out int y);
        return grid.GetGridObject(x, y);
    }

    private void OnDrawGizmos()
    {
        if (pathFinding == null) return;

        var grid = pathFinding.GetGrid();
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode node = grid.GetGridObject(x, y);
                Gizmos.color = node.isWalkable ? Color.white : Color.red;
                Vector3 pos = grid.GetWorldPosition(x, y) + Vector3.one * (cellSize / 2f);
                Gizmos.DrawCube(pos, Vector3.one * (cellSize * 0.9f));
            }
        }
    }

    #region Data
    private void LoadFromData()
    {
        pathFinding = new PathFinding(data.width, data.height, data.offset);

        this.width = data.width;
        this.height = data.height;
        data.Init();

        var grid = pathFinding.GetGrid();
        for (int x = 0; x < data.width; x++)
        {
            for (int y = 0; y < data.height; y++)
            {
                PathNode node = grid.GetGridObject(x, y);
                node.isWalkable = data.GetWalkable(x, y);
            }
        }
    }

    public void SaveToData()
    {
        if (data == null || pathFinding == null) return;

        data.width = this.width;
        data.height = this.height;
        data.Init();

        var grid = pathFinding.GetGrid();
        int total_null = 0, total_walkable = 0;
        for (int x = 0; x < data.width; x++)
        {
            for (int y = 0; y < data.height; y++)
            {
                PathNode node = grid.GetGridObject(x, y);
                if (node == null) total_null++;
                else if (node.isWalkable) total_walkable++;
                data.SetWalkable(x, y, node?.isWalkable ?? true);
            }
        }

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(data);
#endif
    }

    private void OnValidate()
    {
        if (!Application.isPlaying && data != null)
        {
            SaveToData();
            LoadFromData();
        }
    }
    #endregion
}
