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
            if (!burbuja.activeSelf) // Si la burbuja est� desactivada
            {
                // Generar una posici�n aleatoria dentro de los l�mites
                Vector3 posicionAleatoria = new Vector3(
                    Random.Range(limitesMin.x, limitesMax.x), // X aleatoria
                    Random.Range(limitesMin.y, limitesMax.y), // Y aleatoria
                    Random.Range(limitesMin.z, limitesMax.z)  // Z aleatoria
                );

                // Activar la burbuja y moverla a la posici�n aleatoria
                burbuja.transform.position = posicionAleatoria;
                burbuja.SetActive(true);
            }
        }
    } 
}
