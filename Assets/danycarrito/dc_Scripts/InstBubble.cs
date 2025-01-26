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
       // CreateBubbles();
    }


    public void CreateBubbles()
    {
        foreach (GameObject burbuja in bubbles)
        {
            Vector3 newPosition = GenerarPosicionValida();
            burbuja.transform.position = newPosition;
            burbuja.SetActive(true);
        }
    }

    public Vector3 GenerarPosicionValida()
    {
        Vector3 newPosition;

        // Repetir hasta encontrar una posición válida
        do
        {
            newPosition = new Vector3(
                Random.Range(limitesMin.x, limitesMax.x), // X aleatoria
                Random.Range(limitesMin.y, limitesMax.y), // Y aleatoria
                Random.Range(limitesMin.z, limitesMax.z)  // Z aleatoria
            );

        } while (!EsPosicionValida(newPosition));

        return newPosition;
    }

    public bool EsPosicionValida(Vector3 posicion)
    {
        foreach (GameObject burbuja in bubbles)
        {
            // Ignorar la burbuja actual (desactivada o la que se clickea)
            if (burbuja == gameObject || !burbuja.activeSelf) continue;

            // Verificar la distancia con otras burbujas
            if (Vector3.Distance(posicion, burbuja.transform.position) < minDistance)
            {
                return false; // La posición está demasiado cerca de otra burbuja
            }
        }

        return true; // La posición es válida
    }
}
