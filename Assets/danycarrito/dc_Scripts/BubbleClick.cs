using UnityEngine;

public class BubbleClick : MonoBehaviour
{
    public Vector3 limitesMin;
    public Vector3 limitesMax;
    public float minDistance;
    public AudioSource bubbleSound;

    void OnMouseDown()
    {
        if(Timer.Instance.isAlive)
        {
            Vector3 newPosition = new Vector3(
                Random.Range(limitesMin.x, limitesMax.x), 
                Random.Range(limitesMin.y, limitesMax.y), 
                Random.Range(limitesMin.z, limitesMax.z));

            bubbleSound.Play();
            transform.position = newPosition;
            Timer.Instance.score++;
        }
    }


}
