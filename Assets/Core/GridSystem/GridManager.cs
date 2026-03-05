using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float cellSize = 1f;
    public int gridWidth = 20;
    public int gridHeight = 20;

    public Vector2 SnapToGrid(Vector2 position)
    {
        float x = Mathf.Round(position.x / cellSize) * cellSize;
        float y = Mathf.Round(position.y / cellSize) * cellSize;

        return new Vector2(x, y);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.3f);

        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, gridHeight * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }

        for (int y = 0; y <= gridHeight; y++)
        {
            Vector3 start = new Vector3(0, y * cellSize, 0);
            Vector3 end = new Vector3(gridWidth * cellSize, y * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}