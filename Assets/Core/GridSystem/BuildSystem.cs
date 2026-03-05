using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public GridManager grid;
    public GameObject buildingPrefab;

    public void PlaceBuilding(Vector2 worldPosition)
    {
        Vector2 snapped = grid.SnapToGrid(worldPosition);

        Instantiate(
            buildingPrefab,
            new Vector3(snapped.x, snapped.y, 0),
            Quaternion.identity
        );
    }
}