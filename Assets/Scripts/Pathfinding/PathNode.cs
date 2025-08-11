using UnityEngine;

public class PathNode
{
    private Grid<PathNode> grid;
    public int x { get; private set; }
    public int y { get; private set; }
    public int gCost;
    public int hCost;
    public int fCost;
    public bool isWalkable;
    public PathNode cameFromNode;
    public GameObject occupant;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public bool IsOccupied() => occupant != null;
    
}