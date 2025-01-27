using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    [SerializeField] private GameData gameData;

    private void Start() {
        score.text = gameData.playerScore + "p";
    }
    public void restartGame() {
        GameManager.Instance.RestartGame();
    }
}
