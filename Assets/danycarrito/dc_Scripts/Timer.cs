using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public float timer;
    public float timerTutorial;
    public float score;
    public bool isAlive;
    public bool isTutOver;
    public GameObject panelTimer;
    public GameObject panelScore;
    public GameObject panelTutorial;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isAlive = false;
        isTutOver = false;
        panelTutorial.SetActive(true);
        panelScore.SetActive(false);
        panelTimer.SetActive(false);
    }

    void Update()
    {
        int displayTimer = Mathf.Max(0, Mathf.FloorToInt(timer));
        timerText.text = displayTimer.ToString();

        int displayScore = Mathf.Max(0, Mathf.FloorToInt(score));
        scoreText.text = displayScore.ToString();
        
        if(!isTutOver)
        {
            timerTutorial -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            isAlive = false;
            panelScore.SetActive(true);
            panelTimer.SetActive(false);
        }
        else
        {
            timer -= Time.deltaTime;
            panelTimer.SetActive(true);
        }
        if(timerTutorial <= 0 && !isTutOver)
        {
            panelTutorial.SetActive(false);
            isAlive = true;
            isTutOver = true;
        }
    }
}
