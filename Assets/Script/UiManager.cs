using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private RawImage Bg;

    [SerializeField] private TextMeshProUGUI gameTimerText;
    [HideInInspector] public bool gameStart = false;

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

        gameObject.GetComponent<Canvas>().planeDistance = 100;

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
            if (remainingTime > 0)
            {

                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;

                losePanel.SetActive(true);
                gameObject.GetComponent<Canvas>().planeDistance = 1;
                gamepanel.SetActive(false);
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            gameTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            
        }
    }

    

    public void Pause()
    {
        Snake.instance.moveSpeed = 0;
        pausePanel.SetActive(true);
        gameObject.GetComponent<Canvas>().planeDistance = 1;

    }

    public void SnakeDelay()
    {
        Snake.instance.moveSpeed = 2;
    }

    public void Resume()
    {
        Invoke("SnakeDelay", 3f);
        pausePanel.SetActive(false);
        gameObject.GetComponent<Canvas>().planeDistance = 100;

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
