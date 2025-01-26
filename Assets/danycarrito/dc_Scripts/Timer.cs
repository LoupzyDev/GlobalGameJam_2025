using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public float timer;
    public float score;
    public bool isAlive;
    public GameObject panelScore;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
        isAlive = true;
    }

    void Update()
    {
        int displayTimer = Mathf.Max(0, Mathf.FloorToInt(timer));
        timerText.text = displayTimer.ToString();

        int displayScore = Mathf.Max(0, Mathf.FloorToInt(score));
        scoreText.text = displayScore.ToString();

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            isAlive = false;
            panelScore.SetActive(true);
        }
    }
}
