using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private RawImage _img;  //Bg Raw Image
    [SerializeField] private float _x, _y;

    [SerializeField] private GameObject menupanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] public GameObject losePanel;

    [SerializeField] private TextMeshProUGUI gameTimerText;
    [HideInInspector] public bool gameStart = false;

    float remainingTime;
    int score;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalscoreText;

    private void Awake()
    {
        instance = this;
    }

    public void OnStart()
    {
        gameStart = true;
    }

    private void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
        if (gameStart)
        {
            if (remainingTime > 0)
            {

                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;

                losePanel.SetActive(true);
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            gameTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void EndGame()
    {
        gameStart = false;
        menupanel.SetActive(true);
    }

    public void GiveUp()
    {
        score = 0;
        EndGame();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
