using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void GetRandomGame()
    {
        SceneManager.LoadScene(Random.Range(1, 4));
    }
}
