using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public GameObject tilePrefab;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                tile.transform.parent = transform;
            }
        }
    }
}
