using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathManager))]
public class GridEditor : Editor
{
    void OnSceneGUI()
    {
        PathManager pathManager = (PathManager)target;
        Event e = Event.current;

        if (e.type == EventType.MouseDown && e.button == 0) // Left click
        {
            Vector3 mousePos = HandleUtility.GUIPointToWorldRay(e.mousePosition).origin;
            var grid = pathManager.pathFinding.GetGrid();

            grid.GetXYFromWorldPosition(mousePos, out int x, out int y);

            PathNode node = grid.GetGridObject(x, y);
            if (node != null)
            {
                node.isWalkable = !node.isWalkable;
                e.Use();
                EditorUtility.SetDirty(target); // Save changes
            }
        }
    }
}
