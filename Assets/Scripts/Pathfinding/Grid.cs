using System;
using UnityEngine;

public class Grid<TGridObject>
{
    private int width;
    private int height;
    private Vector3 originPosition = Vector3.zero;
    private Vector3Int offsetPosition;
    private TGridObject[,] gridArray;
    private float cellSize;

    public Grid(int width, int height, float cellSize, Vector3Int offsetPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.offsetPosition = offsetPosition;
        gridArray = new TGridObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObject(this, x, y);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.green, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.green, 100f);
            }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.green, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.green, 100f);
    }

    #region GETTER
    public int GetWidth() => width;
    public int GetHeight() => height;
    public float GetCellSize() => cellSize;
    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height) return gridArray[x, y];
        else return default(TGridObject);

    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXYFromWorldPosition(worldPosition, out x, out y);
        return GetGridObject(x, y);

    }

    public Vector3 GetWorldPosition(int x, int y) => (new Vector3(x, y) + offsetPosition) * cellSize;
    public void GetXYFromWorldPosition(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize) - offsetPosition.x;
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize) - offsetPosition.y;
    }
    #endregion
}
