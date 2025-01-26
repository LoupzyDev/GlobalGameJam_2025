using System;
using System.Collections.Generic;
using UnityEngine;

public class GrowObjects : MonoBehaviour
{
    public float growthRate = 1f; 
    public float moveSpeed = 5f; 

    public Vector3 initialScale = new Vector3(1, 1, 1);
    public List<GameObject> boxesToActivate; 
    private int currentBoxIndex = 0; 

    public int score = 0; 
    public TMPro.TextMeshProUGUI scoreText;

    private Camera mainCamera;
    [Range(0, 360)]
    [SerializeField] private float rotationSpeed;

    private Vector3 moveDirection;

    void Start()
    {
        mainCamera = Camera.main;

        transform.localScale = initialScale;

      
        for (int i = 0; i < boxesToActivate.Count; i++)
        {
            boxesToActivate[i].SetActive(i == currentBoxIndex);
        }

        
        UpdateScoreText();
    }

    void Update()
    {

        float moveForward = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveForward = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveForward = -1f; 
        }


        moveDirection = transform.forward * moveForward * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        
        float mouseX = Input.GetAxis("Mouse X");
        if (mouseX != 0)
        {
            transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        }


        float mouseY = Input.GetAxis("Mouse Y");
        if (mouseY != 0)
        {
            transform.Rotate(mouseY * (rotationSpeed * 0.75f) * Time.deltaTime, 0, 0);
        }




        if (Input.GetButton("Fire1"))
        {
           
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }

        
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Dejaste de presionar Fire1, el objeto dejó de crecer.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("AfueraCaja"))
        {
            Debug.Log("Perdiste. El jugador salió de la caja.");
        }

        
        if (other.CompareTag("Meta"))
        {
            Debug.Log("¡Llegaste a la meta!");

            
            score++;
            UpdateScoreText(); 

            
            if (currentBoxIndex < boxesToActivate.Count && boxesToActivate[currentBoxIndex] != null)
            {
                Destroy(boxesToActivate[currentBoxIndex]);
                Debug.Log($"Caja {currentBoxIndex} destruida.");
            }

            
            currentBoxIndex++;
            if (currentBoxIndex < boxesToActivate.Count && boxesToActivate[currentBoxIndex] != null)
            {
                boxesToActivate[currentBoxIndex].SetActive(true);
                Debug.Log($"Caja {currentBoxIndex} activada.");
            }
            else
            {
                Debug.Log("No hay más cajas para activar.");
            }

            
            transform.localScale = initialScale;
            Debug.Log("Tamaño de la burbuja reseteado.");
        }
    }

    
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntuación: " + score.ToString();
        }
    }
}
