using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public RawImage Bg;

    [SerializeField] private TextMeshProUGUI gameTimerText;
    [HideInInspector] public bool gameStart = false;
    private bool isPaused = false;

    public GameObject menuPanel;
    public GameObject gamepanel;
    public GameObject pausePanel;
    public GameObject losePanel;
    public GameObject winpanel;

    public float remainingTime;
    [HideInInspector]public int score;
    int highscore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalscoreText;

    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        instance = this;
    }

    //game start play
    public void OnStart()
    {
        gameStart = true;

        menuPanel.SetActive(false);
        gamepanel.SetActive(true);

        Bg.gameObject.SetActive(false);

        //gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        if (score > highscore)
        {
            highscore = score;
        }

        highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

    private void Update()
    {
        //raw bg movement
        Bg.uvRect = new Rect(Bg.uvRect.position + new Vector2(0.01f, 0.01f) * Time.deltaTime, Bg.uvRect.size);

        //running timer on game screen
        if (gameStart)
        {
            if (!isPaused && remainingTime > 0)
            {

                remainingTime -= Time.deltaTime;

                if (remainingTime <= 0)
                {
                    remainingTime = 0;

                    losePanel.SetActive(true);
                    gameObject.GetComponent<Canvas>().planeDistance = 1;
                    gamepanel.SetActive(false);
                }
            }
            
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            gameTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            
        }
    }

    

    public void Pause()
    {
        Snake.instance.moveSpeed = 0;
        isPaused = true;
        pausePanel.SetActive(true);
        gamepanel.SetActive(false);
        Bg.gameObject.SetActive(true);
        //gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

    }

    public void SnakeDelay()
    {
        Snake.instance.moveSpeed = 2;
    }

    public void Resume()
    {
        Invoke("SnakeDelay", 3f);
        isPaused = false;
        pausePanel.SetActive(false);
        gamepanel.SetActive(true);
        Bg.gameObject.SetActive(false);
        //gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
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
