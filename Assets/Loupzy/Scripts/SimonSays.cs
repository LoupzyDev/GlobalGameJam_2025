using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimonSays : MonoBehaviour {
    public GameObject[] bubbles;

    private List<int> sequence = new List<int>();
    private int currentStep = 0;
    private bool isPlayerTurn = false;

    void Start() {
        StartNewRound();
    }
    void Update() {
        if (isPlayerTurn && Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                for (int i = 0; i < bubbles.Length; i++) {
                    if (hit.collider.gameObject == bubbles[i]) {
                        OnPlayerPressBubble(i);
                        break;
                    }
                }
            }
        }
    }

    private void StartNewRound() {
        isPlayerTurn = false;
        currentStep = 0;


        sequence.Add(Random.Range(0, bubbles.Length));

        StartCoroutine(PlaySequence());
    }


    private void HighlightBubble(int index) {
        var bubble = bubbles[index];
        var material = bubble.GetComponent<Renderer>().material;

        material.color *= 2; 
        bubble.transform.localScale *= 1.2f; 
    }

    private void ResetBubble(int index) {
        var bubble = bubbles[index];
        var material = bubble.GetComponent<Renderer>().material;

        material.color /= 2; 
        bubble.transform.localScale /= 1.2f; 
    }

    public void OnPlayerPressBubble(int bubbleIndex) {
        if (!isPlayerTurn) return;

        StartCoroutine(FeedBack(bubbleIndex));

        if (bubbleIndex == sequence[currentStep]) {
            currentStep++;

            if (currentStep >= sequence.Count) {
                StartNewRound();
            }
        } else {
            GameOver();
        }
    }
    private void GameOver() {
        Debug.Log("Game Over");
        sequence.Clear();
        StartNewRound();
    }
    IEnumerator PlaySequence() {
        foreach (var index in sequence) {
            HighlightBubble(index);
            yield return new WaitForSeconds(0.5f);
            ResetBubble(index);
            yield return new WaitForSeconds(0.2f); 
        }

        isPlayerTurn = true;
    }

    IEnumerator FeedBack(int bubbleIndex) {
        HighlightBubble(bubbleIndex); 
        yield return new WaitForSeconds(0.3f);
        ResetBubble(bubbleIndex);
    }


}
