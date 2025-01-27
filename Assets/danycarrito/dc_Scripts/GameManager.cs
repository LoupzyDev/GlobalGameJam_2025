using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public GameObject pausePanel;
    [SerializeField] private GameData gameData; 

    private void Awake() {

        Instance = this;
        gameData.playerScore = 0;
        if (gameData.remainingScenes == null || gameData.remainingScenes.Count == 0) {
            gameData.ResetRemainingScenes();
        }
    }

    public void GetRandomGame() {
        if (gameData.remainingScenes.Count == 0) {
            SceneManager.LoadScene("Score");
            return;
        }

        int randomIndex = Random.Range(0, gameData.remainingScenes.Count);
        string selectedScene = gameData.remainingScenes[randomIndex];

        gameData.remainingScenes.RemoveAt(randomIndex); 
        SceneManager.LoadScene(selectedScene);
    }

    public void ExitGame() {
        Debug.Log("Cerrando el juego...");
        Application.Quit();
    }

    public void RestartGame() {

        gameData.playerScore = 0;

        gameData.ResetRemainingScenes();

        SceneManager.LoadScene("MainMenu");
    }
    public void UpdatePlayerScore(float scoreToAdd) {
        gameData.playerScore += scoreToAdd; 
        Debug.Log($"Puntaje actualizado: {gameData.playerScore}");
    }
}
