using System.Collections.Generic;
using UnityEngine;

public class InstBubble : MonoBehaviour
{
    public static InstBubble Instance { get; private set; }

    public List<GameObject> bubbles;
    public Vector3 limitesMin; 
    public Vector3 limitesMax;
    public float minDistance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreateBubbles();
    }


    public void CreateBubbles()
    {
        foreach (GameObject burbuja in bubbles)
        {
            if (!burbuja.activeSelf) 
            {

                Vector3 posicionAleatoria = new Vector3(
                    Random.Range(limitesMin.x, limitesMax.x), 
                    Random.Range(limitesMin.y, limitesMax.y), 
                    Random.Range(limitesMin.z, limitesMax.z)  
                );

                burbuja.transform.position = posicionAleatoria;
                burbuja.SetActive(true);
            }
        }
    } 
}
