using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private RawImage menuBg;
    [SerializeField] private RawImage gameBg;

    [SerializeField] private TextMeshProUGUI gameTimerText;
    [HideInInspector] public bool gameStart = false;

    public GameObject menuPanel;
    public GameObject gamePanel;

    public GameObject losePanel;
    public GameObject winpanel;

    public float remainingTime;
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

        menuPanel.SetActive(false);

    }

    private void Update()
    {
        menuBg.uvRect = new Rect(menuBg.uvRect.position + new Vector2(0.01f, 0.01f) * Time.deltaTime, menuBg.uvRect.size);
        gameBg.uvRect = new Rect(menuBg.uvRect.position + new Vector2(0.01f, 0.01f) * Time.deltaTime, menuBg.uvRect.size);

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
        menuPanel.SetActive(true);
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
