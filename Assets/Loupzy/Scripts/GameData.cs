using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameManager/GameData")]
public class GameData : ScriptableObject {
    public List<string> allScenes = new List<string>(); 
    public List<string> remainingScenes = new List<string>(); 
    public float playerScore; 


    public void ResetRemainingScenes() {
        remainingScenes = new List<string>(allScenes);
    }
}
