using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Tile[] tiles;

    public GameObject[] foodPrefab;
    public Vector2Int gridSize;

    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Automatically find all Tile objects in the scene
        tiles = FindObjectsOfType<Tile>();

        SpawnFood();

    }

    void Update()
    {
        if (AllTilesHealthy())
        {
            //Debug.Log("Game Over! All tiles are healthy!");
            UiManager.instance.winpanel.SetActive(true);
            //UiManager.instance.gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            UiManager.instance.Bg.gameObject.SetActive(true);

            UiManager.instance.gamepanel.SetActive(false);

            Snake.instance.moveSpeed = 0;

            UiManager.instance.finalscoreText.text = UiManager.instance.score.ToString();

            PlayerPrefs.SetInt("HighScore", UiManager.instance.score);

        }
    }

    bool AllTilesHealthy()
    {
        foreach (var tile in tiles)
        {
            if (!tile.isHealthy)
                return false;
        }
        return true;
    }

    public void SpawnFood()
    {
        int x = Random.Range(0, gridSize.x);
        int y = Random.Range(0, gridSize.y);
        Instantiate(foodPrefab[Random.Range(0, 6)], new Vector3(x, 0f, y), Quaternion.identity);
    }

}
