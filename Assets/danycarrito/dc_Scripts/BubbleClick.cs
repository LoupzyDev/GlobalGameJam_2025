using UnityEngine;

public class BubbleClick : MonoBehaviour
{
    public Vector3 limitesMin;
    public Vector3 limitesMax;

    private void OnMouseDown()
    {
        Vector3 newPosicion = new Vector3(
           Random.Range(limitesMin.x, limitesMax.x), 
           Random.Range(limitesMin.y, limitesMax.y),
           Random.Range(limitesMin.z, limitesMax.z));

        transform.position = newPosicion; 
    }
}
