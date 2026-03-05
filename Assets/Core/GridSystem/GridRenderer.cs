using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    public float cellSize = 1f;

    public Material lineMaterial;

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        for (int x = 0; x <= width; x++)
        {
            CreateLine(
                new Vector3(x * cellSize, 0.01f, 0),
                new Vector3(x * cellSize, 0.01f, height * cellSize)
            );
        }

        for (int z = 0; z <= height; z++)
        {
            CreateLine(
                new Vector3(0, 0.01f, z * cellSize),
                new Vector3(width * cellSize, 0.01f, z * cellSize)
            );
        }
    }

    void CreateLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("GridLine");
        lineObj.transform.parent = transform;

        LineRenderer lr = lineObj.AddComponent<LineRenderer>();

        lr.material = lineMaterial;
        lr.widthMultiplier = 0.03f;

        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        lr.useWorldSpace = true;
    }
}