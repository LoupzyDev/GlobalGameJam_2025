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
            if (!burbuja.activeSelf) // Si la burbuja está desactivada
            {
                // Generar una posición aleatoria dentro de los límites
                Vector3 posicionAleatoria = new Vector3(
                    Random.Range(limitesMin.x, limitesMax.x), // X aleatoria
                    Random.Range(limitesMin.y, limitesMax.y), // Y aleatoria
                    Random.Range(limitesMin.z, limitesMax.z)  // Z aleatoria
                );

                // Activar la burbuja y moverla a la posición aleatoria
                burbuja.transform.position = posicionAleatoria;
                burbuja.SetActive(true);
            }
        }
    } 
}
